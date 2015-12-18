using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var ep = new IPEndPoint(IPAddress.Loopback, 1444);
            var client = new TcpClient();
            client.Connect(ep);
            var stream = client.GetStream();

            var message = Encoding.ASCII.GetBytes("Hello, World!");
            var message2 = Encoding.ASCII.GetBytes("This is an another message!");

            stream.Write(message, 0, message.Length);
            stream.Write(message2, 0, message2.Length);

            Console.Read();
        }
    }
}
