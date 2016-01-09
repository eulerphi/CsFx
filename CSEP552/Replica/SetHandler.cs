using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replica {
    class SetHandler : IRequestHandler {
        private readonly Func<CommitRequest, bool> commit;
        private readonly Func<PreSetRequest, bool> preSet;

        public SetHandler(
            Func<CommitRequest, bool> commit,
            Func<PreSetRequest, bool> preSet) {

            this.commit = commit;
            this.preSet = preSet;
        }

        public static SetHandler ForConnection(SQLiteConnection connection) {
            return new SetHandler(
                r => Commit(connection, r),
                r => PreSet(connection, r));
        }

        public CommitResponse Commit(CommitRequest request) {
            if (!request.IsSetAction) {
                throw new ArgumentException();
            }

            var result = commit(request);

            return new CommitResponse {
                Committed = result
            };
        }

        public PrepareResponse PreSet(PreSetRequest request) {
            var result = preSet(request);

            return new PrepareResponse {
                CanCommit = result
            };
        }

        public bool TryHandle(IMessage request, out IMessage response) {
            response = null;

            if (request.Type == PreSetRequest.TypeName) {
                response = PreSet((PreSetRequest)request);
            } else if (request.Type == CommitRequest.TypeName) {
                var commitRequest = (CommitRequest)request;
                if (commitRequest.IsSetAction) {
                    response = Commit(commitRequest);
                }
            }

            return response != null;
        }

        private static bool Commit(SQLiteConnection connection, CommitRequest request) {
            using (var tx = connection.BeginTransaction(IsolationLevel.ReadCommitted)) {
                var txCommitted = TransactionManager
                    .ForTransaction(tx)
                    .TryDelete(request.TransactionId);

                if (!txCommitted) {
                    return false;
                }

                KeyValueManager
                    .ForTransaction(tx)
                    .SetValue(request.Key, request.Value);

                tx.Commit();
                return true;
            }
        }

        private static bool PreSet(SQLiteConnection connection, PreSetRequest request) {
            using (var tx = connection.BeginTransaction(IsolationLevel.ReadCommitted)) {
                var manager = TransactionManager.ForTransaction(tx);
                var result = manager.TryCreate(
                    request.TransactionId,
                    TransactionActions.Set,
                    request.Key,
                    request.Value);

                if (result) {
                    tx.Commit();
                }

                return result;
            }
        }
    }
}