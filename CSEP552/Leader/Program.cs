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

            KeyValueLeaderServer
                .Create(createConnection)
                .Start(ServerLookup.Leader);

            Console.ReadKey();
        }

        private static Func<SQLiteConnection> GetCreateConnection() {
            var connectionString = "Data Source=c:\\data\\leader.sqlite;Version=3;";
            return () => new SQLiteConnection(connectionString);
        }

        private static bool ShouldSetupDatabase(string[] args) {
            return args.Length > 0 ? bool.Parse(args[0]) : false;
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
