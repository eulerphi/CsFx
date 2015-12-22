using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Replica
{
    class Program
    {
        static void Main(string[] args)
        {
            var ep = new IPEndPoint(IPAddress.Loopback, 1444);
            var listener = new TcpListener(ep);

            listener.Start();
            while (true)
            {
                listener.AcceptTcpClientAsync()
                        .ContinueWith(Handle, TaskContinuationOptions.OnlyOnRanToCompletion);
            }
        }

        private static void Handle(Task<TcpClient> openClientTask)
        {
            var buffer = new byte[1024];

            using (var client = openClientTask.Result)
            {
                var stream = client.GetStream();
                while (stream.CanRead && stream.CanWrite)
                {
                    Read(stream, buffer, 2);
                    var messageLength = BitConverter.ToInt32(buffer, 0);

                    Read(stream, buffer, messageLength);
                    var message = Encoding.ASCII.GetString(buffer, 0, messageLength);
                    Console.WriteLine(message);
                }
            }
        }

        private static void Read(NetworkStream stream, byte[] buffer, int length)
        {
            var n = 0;
            do
            {
                n += stream.Read(buffer, n, length - n);
            } while (n < length);
        }
    }
}
