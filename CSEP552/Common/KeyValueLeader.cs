using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    class KeyValueLeader {
        private readonly Func<NetworkClient> clientFactory;

        public KeyValueLeader(Func<NetworkClient> clientFactory) {
            this.clientFactory = clientFactory;
        }

        public static KeyValueLeader ForEndpoint(IPEndPoint endpoint) {
            return new KeyValueLeader(() => NetworkClient.ForEndpoint(endpoint));
        }
    }
}
