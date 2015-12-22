using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MessageResolver {
        private readonly string message;

        public string Type { get; set; }

        public MessageResolver(string message, string type) {
            this.message = message;
            Type = type;
        }

        public T Resolve<T>() {
            return JsonConvert.DeserializeObject<T>(message);
        }
    }

    public class NetworkClient
    {
        private const int ReadBufferLength = 1024;
        private const int UShortLength = 2;
        private readonly NetworkStream stream;
        private readonly byte[] readBuffer;

        public NetworkClient(NetworkStream stream)
        {
            this.stream = stream;
            readBuffer = new byte[ReadBufferLength];
        }

        public MessageResolver Read()
        {
            ReadIntoBuffer(UShortLength);
            var length = BitConverter.ToUInt16(readBuffer, 0);

            ReadIntoBuffer(length);
            var message = Encoding.UTF8.GetString(readBuffer, 0, length);

            var baseMessage = JsonConvert.DeserializeObject<BaseMessage>(message);
            return new MessageResolver(message, baseMessage.Type);
        }

        public void Write(object value)
        {
            var message = JsonConvert.SerializeObject(value);
            var messageBuffer = Encoding.UTF8.GetBytes(message);
            var lengthBuffer = BitConverter.GetBytes((ushort)messageBuffer.Length);
            stream.Write(lengthBuffer, 0, lengthBuffer.Length);
            stream.Write(messageBuffer, 0, messageBuffer.Length);
        }

        private void ReadIntoBuffer(int length)
        {
            // TODO : Handle length > ReadBufferLength
            var n = 0;
            do
            {
                n += stream.Read(readBuffer, n, length - n);
            } while (n < length);
        }
    }
}
