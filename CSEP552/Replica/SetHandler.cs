using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replica {
    class SetHandler : IRequestHandler {
        private readonly Action<PreSetRequest> preSet;

        public SetHandler(Action<PreSetRequest> preSet) {
            this.preSet = preSet;
        }

        public static SetHandler ForConnection(SQLiteConnection connection) {
            return new SetHandler(r => PreSet(connection, r));
        }

        public PreSetResponse PreSet(PreSetRequest request) {
            preSet(request);

            return new PreSetResponse {
                CanCommit = true
            };
        }

        public bool TryHandle(BaseMessage request, out BaseMessage response) {
            response = null;

            if (request.Type == PreSetRequest.TypeName) {
                response = PreSet((PreSetRequest)request);
            }

            return response != null;
        }

        private static void PreSet(SQLiteConnection connection, PreSetRequest request) {
            using (var tx = connection.BeginTransaction(IsolationLevel.ReadCommitted)) {
                var updateSql = "UPDATE keyvalues SET value=$value WHERE key=$key";

                var command = new SQLiteCommand(updateSql, connection, tx);
                command.Parameters.AddWithValue("$key", request.Key);
                command.Parameters.AddWithValue("$value", request.Value);

                var rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0) {
                    var insertSql = "INSERT OR IGNORE INTO keyvalues (key, value) VALUES ($key, $value)";
                    var insertCommand = new SQLiteCommand(insertSql, connection, tx);
                    insertCommand.Parameters.AddWithValue("$key", request.Key);
                    insertCommand.Parameters.AddWithValue("$value", request.Value);
                    rowsAffected = insertCommand.ExecuteNonQuery();
                }

                tx.Commit();
            }
        }
    }
}
