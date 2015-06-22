using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.LinkedLists;

namespace CsFxCtCITests.LinkedLists {
    [TestClass]
    public class PartitionListTests {
        [TestMethod]
        public void TestNull() {
            var result = PartitionList.Partition(null, 1);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void TestTwoNoBefore() {
            var head = new LinkedListNode {
                Value = 10,
                Next = new LinkedListNode {
                    Value = 1
                }
            };

            var result = PartitionList.Partition(head, 1);
            Assert.AreEqual(10, result.Value);
            Assert.AreEqual(1, result.Next.Value);
            Assert.AreEqual(null, result.Next.Next);
        }

        [TestMethod]
        public void TestTwoNoAfter() {
            var head = new LinkedListNode {
                Value = 10,
                Next = new LinkedListNode {
                    Value = 1
                }
            };

            var result = PartitionList.Partition(head, 100);
            Assert.AreEqual(10, result.Value);
            Assert.AreEqual(1, result.Next.Value);
            Assert.AreEqual(null, result.Next.Next);
        }

        [TestMethod]
        public void TestTwoWithBeforeAndAfter() {
            var head = new LinkedListNode {
                Value = 10,
                Next = new LinkedListNode {
                    Value = 1
                }
            };

            var result = PartitionList.Partition(head, 5);
            Assert.AreEqual(1, result.Value);
            Assert.AreEqual(10, result.Next.Value);
            Assert.AreEqual(null, result.Next.Next);
        }

    }
}
