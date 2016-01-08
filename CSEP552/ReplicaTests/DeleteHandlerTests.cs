using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Replica;
using System.Data.SQLite;
using Common;
using System.Diagnostics;

namespace ReplicaTests {
    [TestClass]
    public class DeleteHandlerTests {
        private SQLiteConnection connection;
        private string key;
        private KeyValueManager manager;
        private DeleteHandler sut;

        [TestInitialize]
        public void Setup() {
            connection = new SQLiteConnection("Data Source=:memory:");
            connection.Open();
            DatabaseInitializer.CreateTables(connection);

            manager = KeyValueManager.ForConnection(connection);
            sut = DeleteHandler.ForConnection(connection);

            key = Guid.NewGuid().ToString();
        }

        [TestCleanup]
        public void Teardown() {
            connection.Close();
        }

        [TestMethod]
        public void PreDelete_NoConflict() {
            var expected = SetValue();

            var request = CreateRequest();
            var result = sut.PreDelete(request);
            Assert.IsTrue(result.CanCommit);

            Assert.AreEqual(expected, GetValue());
        }

        [TestMethod]
        public void PreDelete_PendingTransaction() {
            var expected = SetValue();

            var request1 = CreateRequest();
            var result = sut.PreDelete(request1);
            Assert.IsTrue(result.CanCommit);

            var request2 = CreateRequest();
            result = sut.PreDelete(request2);
            Assert.IsFalse(result.CanCommit);
            Assert.AreEqual(expected, GetValue());
        }

        [TestMethod]
        public void Commit_NoConflict() {
            SetValue();

            var request = CreateRequest();
            var preSetResponse = sut.PreDelete(request);
            Assert.IsTrue(preSetResponse.CanCommit);

            var commitResponse = sut.Commit(
                request.GetCommitRequest());
            Assert.IsTrue(commitResponse.Committed);
            Assert.AreEqual(null, GetValue());
        }

        [TestMethod]
        public void Commit_TransactionNotPresent() {
            var request = CreateRequest().GetCommitRequest();
            var response = sut.Commit(request);
            Assert.IsFalse(response.Committed);
        }

        [TestMethod]
        public void Commit_Twice() {
            SetValue();
            var request1 = CreateRequest();
            sut.PreDelete(request1);
            sut.Commit(request1.GetCommitRequest());
            Assert.AreEqual(null, GetValue());

            SetValue();
            var request2 = CreateRequest();
            sut.PreDelete(request2);
            sut.Commit(request2.GetCommitRequest());
            Assert.AreEqual(null, GetValue());
        }

        private PreDeleteRequest CreateRequest() {
            return new PreDeleteRequest {
                TransactionId = Guid.NewGuid(),
                Key = key
            };
        }

        private string GetValue() {
            return manager.GetValue(key);
        }

        private string SetValue() {
            var value = Guid.NewGuid().ToString();
            manager.SetValue(key, value);
            return value;
        }
    }
}
