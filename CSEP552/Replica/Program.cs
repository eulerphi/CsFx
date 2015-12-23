using Common;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Replica {
    class Program {
        static void Main(string[] args) {
            var connection = new SQLiteConnection("Data Source=c:\\data\\keyvalue.sqlite;Version=3;");
            connection.Open();

            var replica = KeyValueReplica.ForConnection(connection);

            var endpoint = new IPEndPoint(IPAddress.Loopback, 1444);
            replica.Start(endpoint);
        }
    }
}
