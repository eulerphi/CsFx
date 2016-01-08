using Common;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replica {
    class TransactionManager {
        private readonly Func<string, SQLiteCommand> createCommand;

        public TransactionManager(Func<string, SQLiteCommand> createCommand) {
            this.createCommand = createCommand;
        }

        public static TransactionManager ForTransaction(SQLiteTransaction tx) {
            return new TransactionManager(sql => new SQLiteCommand(sql, tx.Connection, tx));
        }

        public bool TryCreate(
            Guid transactionId,
            TransactionActions action,
            string key,
            string value = null) {

            var sql = "INSERT OR IGNORE INTO transactions " +
                      "(transactionid, action, key, value) " +
                      "VALUES ($transactionid, $action, $key, $value)";

            var command = createCommand(sql);
            command.Parameters.AddWithValue("$transactionid", transactionId);
            command.Parameters.AddWithValue("$action", action);
            command.Parameters.AddWithValue("$key", key);
            command.Parameters.AddWithValue("$value", value);

            var rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public bool TryDelete(Guid transactionId) {

            var sql = "DELETE FROM transactions " +
                      "WHERE transactionid=$transactionid";

            var command = createCommand(sql);
            command.Parameters.AddWithValue("$transactionid", transactionId);

            var rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }
    }
}
