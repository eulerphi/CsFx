using Common;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Replica {
    public class KeyValueReplica {
        private readonly IRequestHandler handler;

        public KeyValueReplica(IRequestHandler handler) {
            this.handler = handler;
        }

        public static KeyValueReplica ForConnection(SQLiteConnection connection) {
            return new KeyValueReplica(DefaultRequestHandler.ForConnection(connection));
        }

        public void Start(IPEndPoint endpoint) {
            var listener = new TcpListener(endpoint);

            listener.Start();
            while (true) {
                listener
                    .AcceptTcpClientAsync()
                    .ContinueWith(Handle, TaskContinuationOptions.OnlyOnRanToCompletion);
            }
        }

        private void Handle(Task<TcpClient> openClientTask) {
            using (var tcpClient = openClientTask.Result) {
                var netClient = new NetworkClient(tcpClient.GetStream());

                do {
                    var request = netClient.Read();

                    BaseMessage response;
                    if (!handler.TryHandle(request, out response)) {
                        throw new ArgumentOutOfRangeException("request");
                    }

                    netClient.Write(response);
                } while (true);
            }
        }
    }
}
