using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Replica {
    class Program {
        static void Main(string[] args) {
            var ep = new IPEndPoint(IPAddress.Loopback, 1444);
            var listener = new TcpListener(ep);

            listener.Start();
            while (true) {
                listener.AcceptTcpClientAsync()
                        .ContinueWith(Handle, TaskContinuationOptions.OnlyOnRanToCompletion);
            }
        }

        private static void Handle(Task<TcpClient> openClientTask) {
            using (var tcpClient = openClientTask.Result) {
                var client = new NetworkClient(tcpClient.GetStream());

                do {
                    var resolver = client.Read();
                    var response = Handle(resolver);
                    client.Write(response);
                } while (true);
            }
        }

        private static BaseMessage Handle(MessageResolver resolver) {
            switch (resolver.Type) {
                case GetValueRequest.TypeName:
                case PreDeleteRequest.TypeName:

                case PreSetRequest.TypeName:
                    return new SetHandler().PreSet(resolver.Resolve<PreSetRequest>());

                default:
                    throw new ArgumentOutOfRangeException("resolver.Type");
            }
        }
    }
}
