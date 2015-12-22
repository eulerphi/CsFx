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
            Foo("2");

            Console.Read();
        }

        static void Foo(string id)
        {
            var ep = new IPEndPoint(IPAddress.Loopback, 1444);
            var client = new TcpClient();
            client.Connect(ep);
            var stream = client.GetStream();

            Write(stream, "Hello, World! " + id);
            Thread.Sleep(5000);
            Write(stream, "This is an another message! " + id);
        }

        private static void Write(NetworkStream stream, string message)
        {
            var messageBuffer = Encoding.UTF8.GetBytes(message);
            var lengthBuffer = BitConverter.GetBytes((ushort)messageBuffer.Length);
            stream.Write(lengthBuffer, 0, lengthBuffer.Length);
            stream.Write(messageBuffer, 0, messageBuffer.Length);
        }
    }
}
