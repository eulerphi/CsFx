using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.LinkedLists;

namespace CsFxCtCITests.LinkedLists {
    [TestClass]
    public class ReverseAdditionTests {
        [TestMethod]
        public void TestBothNull() {
            var result = ReverseAddition.Add(null, null);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void TestOneNull() {
            var a = new LinkedListNode { Value = 1 };

            var result = ReverseAddition.Add(a, null);
            Assert.AreEqual(1, result.Value);
            Assert.AreEqual(null, result.Next);

            result = ReverseAddition.Add(null, a);
            Assert.AreEqual(1, result.Value);
            Assert.AreEqual(null, result.Next);
        }

        [TestMethod]
        public void TestOneElementEach() {
            var a = new LinkedListNode { Value = 1 };
            var b = new LinkedListNode { Value = 5 };

            var result = ReverseAddition.Add(a, b);
            Assert.AreEqual(6, result.Value);
            Assert.AreEqual(null, result.Next);
        }

        [TestMethod]
        public void TestOneElementEachWithOverflow() {
            var a = new LinkedListNode { Value = 1 };
            var b = new LinkedListNode { Value = 9 };

            var result = ReverseAddition.Add(a, b);
            Assert.AreEqual(0, result.Value);
            Assert.AreEqual(1, result.Next.Value);
        }

        [TestMethod]
        public void TestDifferentLenthLists() {
            var a = new LinkedListNode {
                Value = 1,
                Next = new LinkedListNode {
                    Value = 9
                }
            };
            var b = new LinkedListNode { Value = 9 };

            var result = ReverseAddition.Add(a, b);
            Assert.AreEqual(0, result.Value);
            Assert.AreEqual(0, result.Next.Value);
            Assert.AreEqual(1, result.Next.Next.Value);
        }
    }
}
