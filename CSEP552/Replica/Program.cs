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
            var replicaNumber = int.Parse(args[0]);

            var setup = false;
            if (args.Length > 1) {
                setup = bool.Parse(args[1]);
            }

            using (var connection = Connect(replicaNumber, setup)) {
                connection.Open();
                var replica = KeyValueReplica.ForConnection(connection);
                var endpoint = ServerLookup.Replica(replicaNumber);
                replica.Start(endpoint);
                Console.ReadKey();
            }
        }

        private static SQLiteConnection Connect(int replicaNumber, bool setup) {
            if (setup) {
                SetupDatabase(replicaNumber);
            }

            return Connect(replicaNumber);
        }

        private static SQLiteConnection Connect(int replicaNumber) {
            var connectionString = string.Format("Data Source={0};Version=3;", DatabaseFile(replicaNumber));
            return new SQLiteConnection(connectionString);
        }

        private static void SetupDatabase(int replicaNumber) {
            SQLiteConnection.CreateFile(DatabaseFile(replicaNumber));
            using (var connection = Connect(replicaNumber)) {
                connection.Open();
                DatabaseInitializer.CreateTables(connection);
            }
        }

        private static string DatabaseFile(int replicaNumber) {
            return string.Format("c:\\data\\replica{0}.sqlite", replicaNumber);
        }
    }
}
