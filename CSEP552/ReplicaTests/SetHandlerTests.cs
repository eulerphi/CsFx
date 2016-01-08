using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Replica;
using System.Data.SQLite;
using Common;
using System.Diagnostics;

namespace ReplicaTests {
    [TestClass]
    public class SetHandlerTests {
        private SQLiteConnection connection;
        private string key;
        private KeyValueManager manager;
        private SetHandler sut;

        [TestInitialize]
        public void Setup() {
            connection = new SQLiteConnection("Data Source=:memory:");
            connection.Open();
            DatabaseInitializer.CreateTables(connection);

            manager = KeyValueManager.ForConnection(connection);
            sut = SetHandler.ForConnection(connection);

            key = Guid.NewGuid().ToString();
        }

        [TestCleanup]
        public void Teardown() {
            connection.Close();
        }

        [TestMethod]
        public void PreSet_NoConflict() {
            var request = CreateRequest();
            var result = sut.PreSet(request);
            Assert.IsTrue(result.CanCommit);

            Assert.AreEqual(null, GetValue());
        }

        [TestMethod]
        public void PreSet_PendingTransaction() {
            var request1 = CreateRequest();
            var result = sut.PreSet(request1);
            Assert.IsTrue(result.CanCommit);

            var request2 = CreateRequest();
            Debug.Assert(request1.Key == request2.Key);

            result = sut.PreSet(request2);
            Assert.IsFalse(result.CanCommit);
            Assert.AreEqual(null, GetValue());
        }

        [TestMethod]
        public void Commit_NoConflict() {
            var request = CreateRequest();
            var preSetResponse = sut.PreSet(request);
            Assert.IsTrue(preSetResponse.CanCommit);

            var commitResponse = sut.Commit(
                request.GetCommitRequest());
            Assert.IsTrue(commitResponse.Committed);
            Assert.AreEqual(request.Value, GetValue());
        }

        [TestMethod]
        public void Commit_TransactionNotPresent() {
            var request = CreateRequest().GetCommitRequest();
            var response = sut.Commit(request);
            Assert.IsFalse(response.Committed);
        }

        [TestMethod]
        public void Commit_InsertThenUpdate() {
            var request1 = CreateRequest();
            sut.PreSet(request1);
            sut.Commit(request1.GetCommitRequest());
            Assert.AreEqual(request1.Value, GetValue());

            var request2 = CreateRequest();
            sut.PreSet(request2);
            sut.Commit(request2.GetCommitRequest());
            Assert.AreEqual(request2.Value, GetValue());
        }

        private PreSetRequest CreateRequest() {
            return new PreSetRequest {
                TransactionId = Guid.NewGuid(),
                Key = key,
                Value = Guid.NewGuid().ToString()
            };
        }

        private string GetValue() {
            return manager.GetValue(key);
        }

    }
}
