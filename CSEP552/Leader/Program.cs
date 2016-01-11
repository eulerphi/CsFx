using Common;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leader {
    class Program {
        static void Main(string[] args) {
            var createConnection = GetCreateConnection();

            if (ShouldSetupDatabase(args)) {
                SetupDatabase(createConnection);
            }

            var replicaCount = ReplicaCount(args);
            var createEnsemble = GetCreateEnsemble(replicaCount);

            KeyValueLeaderServer
                .Create(createConnection, createEnsemble)
                .Start(ServerLookup.Leader);

            Console.ReadKey();
        }

        private static Func<KeyValueReplicaEnsemble> GetCreateEnsemble(
            int replicaCount) {

            var endpoints = Enumerable
                .Range(0, replicaCount)
                .Select(ServerLookup.Replica)
                .ToList();

            return () => KeyValueReplicaEnsemble.ForEndpoints(endpoints);
        }

        private static int ReplicaCount(string[] args) {
            return int.Parse(args[0]);
        }

        private static Func<SQLiteConnection> GetCreateConnection() {
            var connectionString = "Data Source=c:\\data\\leader.sqlite;Version=3;";
            return () => new SQLiteConnection(connectionString);
        }

        private static bool ShouldSetupDatabase(string[] args) {
            return args.Length > 1 ? bool.Parse(args[1]) : false;
        }

        private static void SetupDatabase(Func<SQLiteConnection> createConnection) {
            using (var connection = createConnection()) {
                connection.Open();

                var sql = "CREATE TABLE IF NOT EXISTS committedtransactions (" +
                          "transactionid TEXT PRIMARY KEY)";

                var command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
