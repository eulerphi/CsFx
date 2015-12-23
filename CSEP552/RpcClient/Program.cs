using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Foo("1");
            //Foo("2");

            Console.Read();
        }

        static void Foo(string id)
        {
            var ep = new IPEndPoint(IPAddress.Loopback, 1444);
            var client = new TcpClient();
            client.Connect(ep);
            var stream = client.GetStream();
            var netClient = new NetworkClient(stream);

            var getRequest = new GetValueRequest {
                Key = "foo"
            };

            netClient.Write(getRequest);
            var response = netClient.Read();

            var setRequest = new PreSetRequest {
                Key = "foo",
                Value = "moo"
            };

            netClient.Write(setRequest);
            response = netClient.Read();

            netClient.Write(getRequest);
            response = netClient.Read();
        }
    }
}
