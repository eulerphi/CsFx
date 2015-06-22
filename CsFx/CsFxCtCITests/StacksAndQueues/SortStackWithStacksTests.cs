using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CsFx.CtCI.StacksAndQueues;

namespace CsFxCtCITests.StacksAndQueues {
    [TestClass]
    public class SortStackWithStacksTests {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullParameter() {
            SortStackWithStacks.Sort(null);
        }

        [TestMethod]
        public void Test() {
            var stack = new Stack<int>();
            stack.Push(5);
            stack.Push(10);
            stack.Push(4);
            stack.Push(6);
            stack.Push(5);

            SortStackWithStacks.Sort(stack);
        }
    }
}
