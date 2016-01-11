using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leader {
    class CommittedTransactionManager {
        private readonly Func<string, SQLiteCommand> createCommand;

        public CommittedTransactionManager(Func<string, SQLiteCommand> createCommand) {
            this.createCommand = createCommand;
        }

        public static CommittedTransactionManager ForConnection(SQLiteConnection connection) {
            return new CommittedTransactionManager(sql => new SQLiteCommand(sql, connection));
        }

        public static CommittedTransactionManager ForTransaction(SQLiteTransaction tx) {
            return new CommittedTransactionManager(sql => new SQLiteCommand(sql, tx.Connection, tx));
        }

        public void Add(Guid transactionId) {
            var sql = "INSERT OR IGNORE " +
                      "INTO committedtransactions " +
                      "(transactionid) " +
                      "VALUES ($transactionid)";

            var command = createCommand(sql);
            command.Parameters.AddWithValue(
                "$transactionid", transactionId);

            command.ExecuteNonQuery();
        }

        public bool Exists(Guid transactionId) {
            var sql = "SELECT COUNT(*) " +
                      "FROM committedtransactions " +
                      "WHERE transactionid=$transactionid";

            var command = createCommand(sql);
            command.Parameters.AddWithValue(
                "$transactionid", transactionId);

            var result = command.ExecuteScalar();
            if (result == null) {
                return false;
            }

            var count = (int)result;
            return count > 0;
        }
    }
}
