using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replica {
    class DatabaseInitializer {
        public static void CreateTables(SQLiteConnection connection) {
            var sql = "CREATE TABLE IF NOT EXISTS keyvalues (" +
                      "key TEXT PRIMARY KEY, " +
                      "value TEXT)";
            var command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();

            sql = "CREATE TABLE IF NOT EXISTS transactions (" +
                  "transactionid TEXT PRIMARY KEY, " +
                  "action TEXT, " +
                  "key TEXT UNIQUE, " +
                  "value TEXT)";

            command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }
}
