using Common;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leader {
    class SetHandler : IRequestHandler {
        private readonly KeyValueReplicaEnsemble ensemble;
        private readonly Action<Guid> markTransactionCommitted;

        public SetHandler(
            KeyValueReplicaEnsemble ensemble,
            Action<Guid> markTransactionCommitted) {

            this.ensemble = ensemble;
            this.markTransactionCommitted = markTransactionCommitted;
        }

        public SetValueResponse Set(SetValueRequest request) {
            var transactionId = Guid.NewGuid();
            var preSetRequest = new PreSetRequest {
                TransactionId = transactionId,
                Key = request.Key,
                Value = request.Value
            };

            using (var dtx = ensemble.SetValue(preSetRequest)) {
                var success = dtx.Run(
                    () => markTransactionCommitted(transactionId));

                return new SetValueResponse {
                    Success = success
                };
            }
        }

        public bool TryHandle(IMessage request, out IMessage response) {
            response = null;

            if (request.Type == SetValueRequest.TypeName) {
                response = Set((SetValueRequest)request);
            }

            return response != null;
        }
    }
}
