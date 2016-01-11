using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leader {
    class GetHandler : IRequestHandler {
        private readonly KeyValueReplicaEnsemble ensemble;

        public GetHandler(KeyValueReplicaEnsemble ensemble) {
            this.ensemble = ensemble;
        }

        public GetValueResponse Get(GetValueRequest request) {
            return ensemble.GetValue(request);
        }

        public bool TryHandle(IMessage request, out IMessage response) {
            response = null;

            if (request.Type == GetValueRequest.TypeName) {
                response = Get((GetValueRequest)request);
            }

            return response != null;
        }
    }
}
