using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.LinkedLists;

namespace CsFxCtCITests.LinkedLists {
    [TestClass]
    public class ForwardAddTests {
        [TestMethod]
        public void TestNullParameters() {
            var node = new LinkedListNode();

            Assert.AreSame(node, ForwardAddition.Add(node, null));
            Assert.AreSame(node, ForwardAddition.Add(null, node));
            Assert.AreEqual(null, ForwardAddition.Add(null, null));
        }

        [TestMethod]
        public void TestSameLengthWithoutOverflow() {
            var a = new LinkedListNode { Value = 1 };
            var b = new LinkedListNode { Value = 2 };
            var result = ForwardAddition.Add(a, b);

            Assert.AreEqual(3, result.Value);
            Assert.AreEqual(null, result.Next);
        }

        [TestMethod]
        public void TestSameLengthWithOverflow() {
            var a = new LinkedListNode { Value = 9 };
            var b = new LinkedListNode { Value = 3 };
            var result = ForwardAddition.Add(a, b);

            Assert.AreEqual(1, result.Value);
            Assert.AreEqual(2, result.Next.Value);
            Assert.AreEqual(null, result.Next.Next);
        }

        [TestMethod]
        public void TestDifferentLengthWithOverflow() {
            var a = new LinkedListNode {
                Value = 9,
                Next = new LinkedListNode {
                    Value = 7
                }
            };
            var b = new LinkedListNode { Value = 8 };
            var result = ForwardAddition.Add(a, b);

            Assert.AreEqual(1, result.Value);
            Assert.AreEqual(0, result.Next.Value);
            Assert.AreEqual(5, result.Next.Next.Value);
            Assert.AreEqual(null, result.Next.Next.Next);
        }
    }
}
