using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.LinkedLists;

namespace CsFxCtCITests.LinkedLists {
    [TestClass]
    public class RemoveDuplicatesTests {
        [TestMethod]
        public void TestNullParameter() {
            try {
                RemoveDuplicates.RemoveWithBuffer(null);
            } catch (Exception) {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestSingleElement() {
            var head = new LinkedListNode { Value = 1 };

            try {
                RemoveDuplicates.RemoveWithBuffer(head);
            } catch (Exception) {
                Assert.Fail();
            }

            Assert.AreEqual(null, head.Next);
            Assert.AreEqual(1, head.Value);
        }

        [TestMethod]
        public void TestTwoElements() {
            var next = new LinkedListNode { Value = 2 };
            var head = new LinkedListNode { Value = 1, Next = next };

            try {
                RemoveDuplicates.RemoveWithBuffer(head);
            } catch (Exception) {
                Assert.Fail();
            }

            Assert.AreEqual(next, head.Next);
            Assert.AreEqual(1, head.Value);

            Assert.AreEqual(null, next.Next);
            Assert.AreEqual(2, next.Value);
        }

        [TestMethod]
        public void TestDuplicateElements() {
            var head = new LinkedListNode {
                Value = 1,
                Next = new LinkedListNode {
                    Value = 1,
                    Next = new LinkedListNode {
                        Value = 1
                    }
                }
            };

            try {
                RemoveDuplicates.RemoveWithBuffer(head);
            } catch (Exception) {
                Assert.Fail();
            }

            Assert.AreEqual(null, head.Next);
            Assert.AreEqual(1, head.Value);
        }

        [TestMethod]
        public void TestNullParameter_WithoutBuffer() {
            try {
                RemoveDuplicates.RemoveWithoutBuffer(null);
            } catch (Exception) {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestSingleElement_WithoutBuffer() {
            var head = new LinkedListNode { Value = 1 };

            try {
                RemoveDuplicates.RemoveWithoutBuffer(head);
            } catch (Exception) {
                Assert.Fail();
            }

            Assert.AreEqual(null, head.Next);
            Assert.AreEqual(1, head.Value);
        }

        [TestMethod]
        public void TestTwoElements_WithoutBuffer() {
            var next = new LinkedListNode { Value = 2 };
            var head = new LinkedListNode { Value = 1, Next = next };

            try {
                RemoveDuplicates.RemoveWithoutBuffer(head);
            } catch (Exception) {
                Assert.Fail();
            }

            Assert.AreEqual(next, head.Next);
            Assert.AreEqual(1, head.Value);

            Assert.AreEqual(null, next.Next);
            Assert.AreEqual(2, next.Value);
        }

        [TestMethod]
        public void TestDuplicateElements_WithoutBuffer() {
            var head = new LinkedListNode {
                Value = 1,
                Next = new LinkedListNode {
                    Value = 1,
                    Next = new LinkedListNode {
                        Value = 1
                    }
                }
            };

            try {
                RemoveDuplicates.RemoveWithoutBuffer(head);
            } catch (Exception) {
                Assert.Fail();
            }

            Assert.AreEqual(null, head.Next);
            Assert.AreEqual(1, head.Value);
        }
    }
}
