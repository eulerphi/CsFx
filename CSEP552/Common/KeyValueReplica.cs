using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    public class KeyValueReplica {
        private readonly Func<NetworkClient> clientFactory;

        public KeyValueReplica(Func<NetworkClient> clientFactory) {
            this.clientFactory = clientFactory;
        }

        public static KeyValueReplica ForEndpoint(IPEndPoint endpoint) {
            return new KeyValueReplica(() => NetworkClient.ForEndpoint(endpoint));
        }

        public string Get(string key) {
            using (var client = clientFactory()) {
                client.Write(new GetValueRequest {
                    Key = key
                });

                var response = client.Read<GetValueResponse>();
                return response.Value;
            }
        }

        public TwoPhaseTransaction StartDelete(string key) {
            var request = new PreDeleteRequest {
                Key = key,
                TransactionId = Guid.NewGuid()
            };
            return StartDelete(request);
        }

        public TwoPhaseTransaction StartDelete(PreDeleteRequest request) {
            return new TwoPhaseTransaction(clientFactory(), request);
        }

        public TwoPhaseTransaction StartSet(string key, string value) {
            var request = new PreSetRequest {
                Key = key,
                TransactionId = Guid.NewGuid(),
                Value = value
            };

            return StartSet(request);
        }

        public TwoPhaseTransaction StartSet(PreSetRequest request) {
            return new TwoPhaseTransaction(clientFactory(), request);
        }
    }
}
