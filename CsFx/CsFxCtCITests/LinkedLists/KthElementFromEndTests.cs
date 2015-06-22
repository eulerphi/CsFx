using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.LinkedLists;

namespace CsFxCtCITests.LinkedLists {
    [TestClass]
    public class KthElementFromEndTests {
        [TestMethod]
        public void TestEmptyList() {
            var head = (LinkedListNode)null;

            var result = KthElementFromEnd.Find(head, 2);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void TestTooLargeK() {
            var head = new LinkedListNode {
                Value = 1,
                Next = new LinkedListNode { Value = 2 }
            };

            var result = KthElementFromEnd.Find(head, 5);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void TestZeroIndexed() {
            var head = new LinkedListNode {
                Value = 1,
                Next = new LinkedListNode { Value = 2 }
            };

            Assert.AreEqual(2, KthElementFromEnd.Find(head, 0).Value);
            Assert.AreEqual(1, KthElementFromEnd.Find(head, 1).Value);
        }
    }
}
