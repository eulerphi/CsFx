using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.LinkedLists;

namespace CsFxCtCITests.LinkedLists {
    [TestClass]
    public class DeleteFromMiddleTests {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNull() {
            DeleteFromMiddle.Delete(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTailElement() {
            DeleteFromMiddle.Delete(new LinkedListNode());
        }

        [TestMethod]
        public void TestGreen() {
            var node3 = new LinkedListNode { Value = 3 };
            var node2 = new LinkedListNode { Value = 2, Next = node3 };
            var node1 = new LinkedListNode { Value = 1, Next = node3 };

            DeleteFromMiddle.Delete(node2);

            Assert.AreEqual(1, node1.Value);
            Assert.AreEqual(3, node1.Next.Value);
            Assert.AreEqual(null, node1.Next.Next);
        }
    }
}
