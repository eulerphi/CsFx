using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leader {
    class GetHandler {
        private readonly IList<KeyValueReplica> replicas;

        public GetHandler(IList<KeyValueReplica> replicas) {
            this.replicas = replicas;
        }

        public GetValueResponse Get(GetValueRequest request) {
            var replica = replicas.SelectRandom();
            var value = replica.Get(request.Key);

            return new GetValueResponse {
                Value = value
            };
        }

    }
}
