using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    public class TwoPhaseTransaction : IDisposable {
        private readonly NetworkClient client;
        private readonly IPrepareRequest request;

        public bool Closed => State == TwoPhaseCommitState.Aborted || State == TwoPhaseCommitState.Committed;
        public TwoPhaseCommitState State { get; private set; }

        public TwoPhaseTransaction(NetworkClient client, IPrepareRequest request) {
            this.client = client;
            this.request = request;
        }

        public void Abort() {
            if (Closed) {
                throw new TransactionClosedException();
            }

            var aborted = false;
            if (State == TwoPhaseCommitState.Started) {
                aborted = true;
            } else if (State == TwoPhaseCommitState.Prepared) {
                client.Write(request.GetAbortRequest());
                var response = client.Read<AbortResponse>();
                aborted = response.Aborted;
            } else {
                throw new InvalidOperationException();
            }

            if (!aborted) {
                throw new InvalidOperationException();
            }

            State = TwoPhaseCommitState.Aborted;
        }

        public void Commit() {
            if (Closed) {
                throw new TransactionClosedException();
            }

            var committed = false;
            if (State == TwoPhaseCommitState.Started) {
                committed = true;
            } else if (State == TwoPhaseCommitState.Prepared) {
                client.Write(request.GetCommitRequest());
                var response = client.Read<CommitResponse>();

                committed = response.Committed;
            } else {
                throw new InvalidOperationException();
            }

            if (!committed) {
                throw new InvalidOperationException();
            }

            State = TwoPhaseCommitState.Committed;
        }

        public bool Prepare() {
            if (Closed) {
                throw new TransactionClosedException();
            }

            var prepared = false;
            if (State == TwoPhaseCommitState.Prepared) {
                prepared = true;
            } else if (State == TwoPhaseCommitState.Started) {
                client.Write(request);
                var response = client.Read<PrepareResponse>();

                prepared = response.CanCommit;
            } else {
                throw new InvalidOperationException();
            }

            State = prepared
                ? TwoPhaseCommitState.Prepared
                : TwoPhaseCommitState.Aborted;

            return State == TwoPhaseCommitState.Prepared;
        }

        public void Dispose() {
            if (State == TwoPhaseCommitState.Prepared) {
                Abort();
            }

            client.Dispose();
        }
    }

}
