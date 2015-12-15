using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.SQLite;
using System.Net.Http;
using System.Web.Http;
using System.Data;

namespace KeyValueStore.Controllers
{
    public class KeyValueController : ApiController
    {
        private SQLiteConnection connection;

        public KeyValueController()
        {
            //SQLiteConnection.CreateFile("c:\\data\\keyvalue.sqlite");
            connection = new SQLiteConnection("Data Source=c:\\data\\keyvalue.sqlite;Version=3;");
            connection.Open();

            //var sql = "CREATE TABLE keyvalues (key TEXT PRIMARY KEY, value TEXT)";
            //var command = new SQLiteCommand(sql, connection);
            //command.ExecuteNonQuery();
        }

        // GET: api/KeyValue/5
        public string Get(string id)
        {

            using (var tx = connection.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                var selectSql = "SELECT value FROM keyvalues WHERE key=$key";

                var command = new SQLiteCommand(selectSql, connection, tx);
                command.Parameters.AddWithValue("$key", id);
                var result = command.ExecuteScalar();

                tx.Commit();

                if (result == null)
                {
                    return null;
                }

                var dbNull = result as DBNull;
                if (dbNull != null)
                {
                    return null;
                }

                return (string)result;
            }
        }

        // PUT: api/KeyValue/5
        public void Put(string id, [FromBody]string value)
        {
            using (var tx = connection.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                var updateSql = "UPDATE keyvalues SET value=$value WHERE key=$key";

                var command = new SQLiteCommand(updateSql, connection, tx);
                command.Parameters.AddWithValue("$key", id);
                command.Parameters.AddWithValue("$value", value);

                var rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    var insertSql = "INSERT OR IGNORE INTO keyvalues (key, value) VALUES ($key, $value)";
                    var insertCommand = new SQLiteCommand(insertSql, connection, tx);
                    insertCommand.Parameters.AddWithValue("$key", id);
                    insertCommand.Parameters.AddWithValue("$value", value);
                    rowsAffected = insertCommand.ExecuteNonQuery();
                }

                tx.Commit();
            }
        }

        // DELETE: api/KeyValue/5
        public void Delete(string id)
        {
            using (var tx = connection.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                var deleteSql = "DELETE FROM keyvalues WHERE key=$key";

                var command = new SQLiteCommand(deleteSql, connection, tx);
                command.Parameters.AddWithValue("$key", id);
                var rowsAffected = command.ExecuteNonQuery();

                tx.Commit();
            }
        }
    }
}
