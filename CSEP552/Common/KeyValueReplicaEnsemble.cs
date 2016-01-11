using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    public class KeyValueReplicaEnsemble {
        private readonly IList<KeyValueReplica> replicas;

        public KeyValueReplicaEnsemble(IList<KeyValueReplica> replicas) {
            this.replicas = replicas;
        }

        public static KeyValueReplicaEnsemble ForEndpoints(
            IList<IPEndPoint> endpoints) {

            var replicas = endpoints
                .Select(KeyValueReplica.ForEndpoint)
                .ToList();
            return new KeyValueReplicaEnsemble(replicas);
        }

        public DistributedTwoPhaseTransaction DeleteValue(PreDeleteRequest request) {
            var transactions = replicas
                .Select(r => r.StartDelete(request))
                .ToList();

            return new DistributedTwoPhaseTransaction(transactions);
        }

        public GetValueResponse GetValue(GetValueRequest request) {
            var replica = replicas.SelectRandom();
            var value = replica.Get(request.Key);

            return new GetValueResponse {
                Value = value
            };
        }

        public DistributedTwoPhaseTransaction SetValue(PreSetRequest request) {
            var transactions = replicas
                .Select(r => r.StartSet(request))
                .ToList();

            return new DistributedTwoPhaseTransaction(transactions);
        }
    }
}
