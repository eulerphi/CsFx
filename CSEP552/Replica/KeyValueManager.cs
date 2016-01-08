using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replica {
    class KeyValueManager {
        private readonly Func<string, SQLiteCommand> createCommand;

        public KeyValueManager(Func<string, SQLiteCommand> createCommand) {
            this.createCommand = createCommand;
        }

        public static KeyValueManager ForConnection(SQLiteConnection connection) {
            return new KeyValueManager(sql => new SQLiteCommand(sql, connection));
        }

        public static KeyValueManager ForTransaction(SQLiteTransaction tx) {
            return new KeyValueManager(sql => new SQLiteCommand(sql, tx.Connection, tx));
        }

        public void DeleteValue(string key) {
            var sql = "DELETE FROM keyvalues " +
                      "WHERE key=$key";

            var command = createCommand(sql);
            command.Parameters.AddWithValue("$key", key);

            command.ExecuteNonQuery();
        }

        public string GetValue(string key) {
            var sql = "SELECT value " +
                      "FROM keyvalues " +
                      "WHERE key=$key";

            var command = createCommand(sql);
            command.Parameters.AddWithValue("$key", key);

            var result = command.ExecuteScalar();
            if (result == null) {
                return null;
            }

            var dbNull = result as DBNull;
            if (dbNull != null) {
                return null;
            }

            return (string)result;
        }

        public void SetValue(string key, string value) {
            var result = TryUpdate(key, value) || TryInsert(key, value);

            if (!result) {
                throw new InvalidOperationException();
            }
        }

        private bool TryUpdate(string key, string value) {
            var sql = "UPDATE keyvalues " +
                      "SET value=$value " +
                      "WHERE key=$key";

            var command = createCommand(sql);
            command.Parameters.AddWithValue("$key", key);
            command.Parameters.AddWithValue("$value", value);

            var rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        private bool TryInsert(string key, string value) {
            var sql = "INSERT OR IGNORE INTO keyvalues " +
                      "(key, value) " +
                      "VALUES ($key, $value)";

            var command = createCommand(sql);
            command.Parameters.AddWithValue("$key", key);
            command.Parameters.AddWithValue("$value", value);

            var rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }
    }
}
