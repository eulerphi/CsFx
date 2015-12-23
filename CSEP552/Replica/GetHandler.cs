using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data.SQLite;
using System.Data;

namespace Replica {
    class GetHandler : IRequestHandler {
        private readonly Func<string, string> get;

        public GetHandler(Func<string, string> get) {
            this.get = get;
        }

        public static GetHandler ForConnection(SQLiteConnection connection) {
            return new GetHandler(id => Get(connection, id));
        }

        public GetValueResponse Get(GetValueRequest request) {
            return new GetValueResponse {
                Value = get(request.Key)
            };
        }

        public bool TryHandle(BaseMessage request, out BaseMessage response) {
            response = null;

            if (request.Type == GetValueRequest.TypeName) {
                response = Get((GetValueRequest)request);
            }

            return response != null;
        }

        private static string Get(SQLiteConnection connection, string id) {
            using (var tx = connection.BeginTransaction(IsolationLevel.ReadCommitted)) {
                var selectSql = "SELECT value FROM keyvalues WHERE key=$key";

                var command = new SQLiteCommand(selectSql, connection, tx);
                command.Parameters.AddWithValue("$key", id);
                var result = command.ExecuteScalar();

                tx.Commit();

                var dbNull = result as DBNull;
                if (dbNull != null) {
                    return null;
                }

                return (string)result;
            }
        }
    }
}
