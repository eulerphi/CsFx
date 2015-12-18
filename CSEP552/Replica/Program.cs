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
            while(true)
            {
                listener.AcceptTcpClientAsync()
                        .ContinueWith(Handle, TaskContinuationOptions.OnlyOnRanToCompletion);
            }
        }

        private static void Handle(Task<TcpClient> openClientTask)
        {
            var buffer = new byte[1024];

            var stream = openClientTask.Result.GetStream();
            var offset = 0;
            while (stream.DataAvailable)
            {
                var n = stream.Read(buffer, offset, buffer.Length);
                offset += n;

                var message = Encoding.ASCII.GetString(buffer, 0, n);
                Console.WriteLine(message);
            }

        }
    }
}
