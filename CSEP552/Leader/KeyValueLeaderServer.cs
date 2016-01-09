using Common;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Leader {
    class KeyValueLeaderServer {
        private readonly Func<SQLiteConnection> createConnection;
        private readonly Func<SQLiteConnection, IRequestHandler> createHandler;

        public KeyValueLeaderServer(
            Func<SQLiteConnection> createConnection,
            Func<SQLiteConnection, IRequestHandler> createHandler) {

            this.createConnection = createConnection;
            this.createHandler = createHandler;
        }

        public static KeyValueLeaderServer Create(
            Func<SQLiteConnection> createConnection) {

            return new KeyValueLeaderServer(
                createConnection,
                DefaultRequestHandler.ForConnection);
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
                using (var connection = createConnection()) {
                    var netClient = new NetworkClient(tcpClient.GetStream());
                    var handler = createHandler(connection);

                    do {
                        var request = netClient.Read();

                        IMessage response;
                        if (!handler.TryHandle(request, out response)) {
                            throw new ArgumentOutOfRangeException("request");
                        }

                        netClient.Write(response);
                    } while (true);
                }
            }
        }
    }
}
