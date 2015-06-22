using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.StacksAndQueues;

namespace CsFxCtCITests.StacksAndQueues {
    [TestClass]
    public class StackWithMinTests {
        [TestMethod]
        public void TestOneValue() {
            var stack = new StackWithMin();
            stack.Push(1);
            Assert.AreEqual(1, stack.Min());
            Assert.AreEqual(1, stack.Pop());
        }

        [TestMethod]
        public void TestTwoValues_BothSame() {
            var stack = new StackWithMin();
            stack.Push(1);
            stack.Push(1);
            Assert.AreEqual(1, stack.Min());
            Assert.AreEqual(1, stack.Pop());

            Assert.AreEqual(1, stack.Min());
            Assert.AreEqual(1, stack.Pop());
        }

        [TestMethod]
        public void TestTwoValues_SecondBigger() {
            var stack = new StackWithMin();
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(1, stack.Min());
            Assert.AreEqual(2, stack.Pop());

            Assert.AreEqual(1, stack.Min());
            Assert.AreEqual(1, stack.Pop());
        }

        [TestMethod]
        public void TestTwoValues_SecondSmaller() {
            var stack = new StackWithMin();
            stack.Push(2);
            stack.Push(1);
            Assert.AreEqual(1, stack.Min());
            Assert.AreEqual(1, stack.Pop());

            Assert.AreEqual(2, stack.Min());
            Assert.AreEqual(2, stack.Pop());
        }
    }
}
