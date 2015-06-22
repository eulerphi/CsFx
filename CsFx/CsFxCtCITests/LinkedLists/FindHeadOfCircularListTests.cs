using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.LinkedLists;

namespace CsFxCtCITests.LinkedLists {
    [TestClass]
    public class FindHeadOfCircularListTests {
        [TestMethod]
        public void TestNullParameter() {
            Assert.AreEqual(null, FindHeadOfCircularList.Find(null));
        }

        [TestMethod]
        public void TestNonCircularList() {
            var head = new LinkedListNode {
                Next = new LinkedListNode()
            };

            Assert.AreEqual(null, FindHeadOfCircularList.Find(head));
            Assert.AreEqual(null, FindHeadOfCircularList.Find(head.Next));
        }

        [TestMethod]
        public void TestAllCircular() {
            var tail = new LinkedListNode();
            var head = new LinkedListNode {
                Next = new LinkedListNode {
                    Next = new LinkedListNode {
                        Next = tail
                    }
                }
            };

            tail.Next = head;

            Assert.AreEqual(
                head,
                FindHeadOfCircularList.Find(head));
            Assert.AreEqual(
                head.Next,
                FindHeadOfCircularList.Find(head.Next));
            Assert.AreEqual(
                head.Next.Next,
                FindHeadOfCircularList.Find(head.Next.Next));
            Assert.AreEqual(
                head.Next.Next.Next,
                FindHeadOfCircularList.Find(head.Next.Next.Next));
        }

        [TestMethod]
        public void TestCircularLater() {
            var circularTail = new LinkedListNode();
            var circularHead = new LinkedListNode {
                Next = new LinkedListNode {
                    Next = circularTail
                }
            };
            circularTail.Next = circularHead;

            var head = new LinkedListNode {
                Next = new LinkedListNode {
                    Next = circularHead
                }
            };

            Assert.AreEqual(
                circularHead,
                FindHeadOfCircularList.Find(head));
            Assert.AreEqual(
                circularHead,
                FindHeadOfCircularList.Find(head.Next));
        }
    }
}
