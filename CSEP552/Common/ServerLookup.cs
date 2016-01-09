using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    public class ServerLookup {
        private static int BasePort = 1111;

        public static IPEndPoint Leader => new IPEndPoint(IPAddress.Loopback, BasePort);

        public static IPEndPoint Replica(int number) {
            return new IPEndPoint(IPAddress.Loopback, BasePort + number + 1);
        }
    }
}
