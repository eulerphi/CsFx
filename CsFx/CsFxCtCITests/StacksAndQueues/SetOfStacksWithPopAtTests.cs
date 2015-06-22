using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.StacksAndQueues;

namespace CsFxCtCITests.StacksAndQueues {
    [TestClass]
    public class SetOfStacksWithPopAtTests {
        [TestMethod]
        public void TestCtorParameter_Red() {
            var nonPositiveValues = new int[] { 0, -1, -2 };

            foreach (var param in nonPositiveValues) {
                try {
                    new SetOfStacksWithPopAt(param);
                    Assert.Fail("Exception expected");
                } catch (ArgumentException) {
                    // Expected
                } catch (Exception e) {
                    Assert.Fail("Unexpected exception");
                }
            }
        }

        [TestMethod]
        public void TestMultipleStacks() {
            var stack = new SetOfStacksWithPopAt(stackLimit: 2);
            stack.Push(10);
            stack.Push(11);
            stack.Push(20);

            var info = stack.GetStacksInfo();
            Assert.AreEqual(2, info.Length);
            Assert.AreEqual(2, info[0]);
            Assert.AreEqual(1, info[1]);

            Assert.AreEqual(20, stack.Pop());
            info = stack.GetStacksInfo();
            Assert.AreEqual(1, info.Length);
            Assert.AreEqual(2, info[0]);

            Assert.AreEqual(11, stack.Pop());
            Assert.AreEqual(10, stack.Pop());
            info = stack.GetStacksInfo();
            Assert.AreEqual(0, info.Length);
        }

        [TestMethod]
        public void TestPopAt() {
            var stack = new SetOfStacksWithPopAt(stackLimit: 1);
            stack.Push(10);
            stack.Push(11);
            stack.Push(20);

            Assert.AreEqual(10, stack.PopAt(0));
            Assert.AreEqual(11, stack.PopAt(0));
            Assert.AreEqual(20, stack.PopAt(0));
        }
    }
}
