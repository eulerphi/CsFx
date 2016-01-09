using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data.SQLite;
using System.Data;

namespace Replica {
    class DeleteHandler : IRequestHandler {
        private readonly Func<CommitRequest, bool> commit;
        private readonly Func<PreDeleteRequest, bool> preDelete;

        public DeleteHandler(
            Func<CommitRequest, bool> commit,
            Func<PreDeleteRequest, bool> preDelete) {

            this.commit = commit;
            this.preDelete = preDelete;
        }

        public static DeleteHandler ForConnection(SQLiteConnection connection) {
            return new DeleteHandler(
                r => Commit(connection, r),
                r => PreDelete(connection, r));
        }

        public CommitResponse Commit(CommitRequest request) {
            if (!request.IsDeleteAction) {
                throw new ArgumentException();
            }

            var result = commit(request);

            return new CommitResponse {
                Committed = result
            };
        }

        public PrepareResponse PreDelete(PreDeleteRequest request) {
            var result = preDelete(request);

            return new PrepareResponse {
                CanCommit = result
            };
        }

        public bool TryHandle(IMessage request, out IMessage response) {
            response = null;

            if (request.Type == PreDeleteRequest.TypeName) {
                response = PreDelete((PreDeleteRequest)request);
            } else if (request.Type == CommitRequest.TypeName) {
                var commitRequest = (CommitRequest)request;
                if (commitRequest.IsDeleteAction) {
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
                    .DeleteValue(request.Key);

                tx.Commit();
                return true;
            }
        }

        private static bool PreDelete(SQLiteConnection connection, PreDeleteRequest request) {
            using (var tx = connection.BeginTransaction(IsolationLevel.ReadCommitted)) {
                var manager = TransactionManager.ForTransaction(tx);
                var result = manager.TryCreate(
                    request.TransactionId,
                    TransactionActions.Delete,
                    request.Key);

                if (result) {
                    tx.Commit();
                }

                return result;
            }
        }
    }
}
