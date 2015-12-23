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
        private const int ReadBufferLength = 1024;
        private const int UShortLength = 2;
        private readonly byte[] readBuffer;
        private readonly MessageResolver resolver;
        private readonly NetworkStream stream;

        public NetworkClient(NetworkStream stream)
        {
            this.stream = stream;
            readBuffer = new byte[ReadBufferLength];
            resolver = new MessageResolver();
        }

        public BaseMessage Read()
        {
            ReadIntoBuffer(UShortLength);
            var length = BitConverter.ToUInt16(readBuffer, 0);

            ReadIntoBuffer(length);
            var message = Encoding.UTF8.GetString(readBuffer, 0, length);

            var envelope = JsonConvert.DeserializeObject<MessageEnvelope>(message);
            return resolver.Resolve(envelope);
        }

        public void Write(BaseMessage message)
        {
            var envelope = new MessageEnvelope {
                Type = message.Type,
                Message = JsonConvert.SerializeObject(message)
            };
            var serializedEnvelope = JsonConvert.SerializeObject(envelope);
            var envelopeBuffer = Encoding.UTF8.GetBytes(serializedEnvelope);
            var lengthBuffer = BitConverter.GetBytes((ushort)envelopeBuffer.Length);
            stream.Write(lengthBuffer, 0, lengthBuffer.Length);
            stream.Write(envelopeBuffer, 0, envelopeBuffer.Length);
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
