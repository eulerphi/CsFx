using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using CsFx.CtCI.StacksAndQueues;

namespace CsFxCtCITests.StacksAndQueues {
    [TestClass]
    public class TowerOfHanoiTests {
        [TestMethod]
        public void Test() {
            for (var i = 0; i < 10; i++) {
                var source = new Stack<int>();

                for (var j = i; j > 0; j--) {
                    source.Push(j);
                }

                var destination = new Stack<int>();
                var buffer = new Stack<int>();

                TowerOfHanoi.Solve(source, destination, buffer);

                for (var j = 1; j <= i; j++) {
                    Assert.AreEqual(j, destination.Pop());
                }

                Assert.AreEqual(0, source.Count);
                Assert.AreEqual(0, buffer.Count);
            }
        }
    }
}
