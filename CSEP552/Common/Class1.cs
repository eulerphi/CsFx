using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class NetworkClient
    {
        private const int USHORT_LENGTH = 2;
        private readonly NetworkStream stream;
        private readonly byte[] readBuffer;
        private readonly byte[] lengthBuffer;

        public NetworkClient(NetworkStream stream)
        {
            this.stream = stream;
            readBuffer = new byte[1024];
            lengthBuffer = new byte[2];
        }

        public T Read<T>()
        {
            ReadIntoBuffer(USHORT_LENGTH);
            var length = BitConverter.ToUInt16(readBuffer, 0);

            ReadIntoBuffer(length);
            var body = Encoding.UTF8.GetString(readBuffer, 0, length);

            return JsonConvert.DeserializeObject<T>(body);
        }

        private void ReadIntoBuffer(int length)
        {
            var n = 0;
            do
            {
                n += stream.Read(readBuffer, n, length - n);
            } while (n < length);
        }

        //public static void WriteMessage(this NetworkStream stream, byte[] buffer, int offset, int length)
        //{
        //    var lengthBuffer = BitConverter.GetBytes((ushort)buffer.Length);
        //    stream.Write(lengthBuffer, 0, lengthBuffer.Length);
        //    stream.Write(buffer, 0, buffer.Length);
        //}

        //public static void WriteMessage(this NetworkStream stream, string message)
        //{
        //    var buffer = Encoding.UTF8.GetBytes(message);
        //    stream.Write(buffer, )

        //}
    }
}
