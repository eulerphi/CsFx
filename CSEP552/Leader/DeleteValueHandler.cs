using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leader {
    class DeleteValueHandler : IRequestHandler {
        private readonly KeyValueReplicaEnsemble ensemble;
        private readonly Action<Guid> markTransactionCommitted;

        public DeleteValueHandler(
            KeyValueReplicaEnsemble ensemble,
            Action<Guid> markTransactionCommitted) {

            this.ensemble = ensemble;
            this.markTransactionCommitted = markTransactionCommitted;
        }

        public DeleteValueResponse DeleteValue(
            DeleteValueRequest request) {

            var transactionId = Guid.NewGuid();
            var preSetRequest = new PreDeleteRequest {
                TransactionId = transactionId,
                Key = request.Key,
            };

            using (var dtx = ensemble.DeleteValue(preSetRequest)) {
                var success = dtx.Run(
                    () => markTransactionCommitted(transactionId));

                return new DeleteValueResponse {
                    Success = success
                };
            }
        }
        public bool TryHandle(IMessage request, out IMessage response) {
            response = null;

            if (request.Type == DeleteValueRequest.TypeName) {
                response = DeleteValue((DeleteValueRequest)request);
            }

            return response != null;
        }
    }
}
