using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.StacksAndQueues;

namespace CsFxCtCITests.StacksAndQueues {
    [TestClass]
    public class QueueWithTwoStacksTests {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestEmptyDequeue() {
            var queue = new QueueWithTwoStacks();
            Assert.AreEqual(0, queue.Count);
            queue.Dequeue();
        }

        [TestMethod]
        public void TestEnqueueDequeue() {
            var queue = new QueueWithTwoStacks();
            queue.Enqueue(10);
            Assert.AreEqual(1, queue.Count);
            Assert.AreEqual(10, queue.Dequeue());
            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        public void TestEnqueueEnqueueDequeueDequeue() {
            var queue = new QueueWithTwoStacks();
            queue.Enqueue(10);
            queue.Enqueue(20);

            Assert.AreEqual(2, queue.Count);
            Assert.AreEqual(10, queue.Dequeue());

            Assert.AreEqual(1, queue.Count);
            Assert.AreEqual(20, queue.Dequeue());

            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        public void TestEnqueueEnqueueDequeueEnqueueDequeueDequeue() {
            var queue = new QueueWithTwoStacks();
            queue.Enqueue(10);
            queue.Enqueue(20);

            Assert.AreEqual(2, queue.Count);
            Assert.AreEqual(10, queue.Dequeue());

            queue.Enqueue(30);
            Assert.AreEqual(2, queue.Count);
            Assert.AreEqual(20, queue.Dequeue());

            Assert.AreEqual(1, queue.Count);
            Assert.AreEqual(30, queue.Dequeue());

            Assert.AreEqual(0, queue.Count);
        }
    }
}
