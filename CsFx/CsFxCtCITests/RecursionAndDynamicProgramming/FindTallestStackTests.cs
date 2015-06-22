using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.RecursionAndDynamicProgramming;

namespace CsFxCtCITests.RecursionAndDynamicProgramming {
    [TestClass]
    public class FindTallestStackTests {
        [TestMethod]
        public void TestAllStack() {
            var boxes = new Box[] {
                new Box(1, 2, 3),
                new Box(2, 3, 4),
                new Box(3, 4, 5)
            };

            var result = FindTallestStack.Find(boxes);

            Assert.AreEqual(9, result.Sum(b => b.Height));
        }

        [TestMethod]
        public void TestNoneStack() {
            var boxes = new Box[] {
                new Box(1, 2, 3),
                new Box(2, 2, 2),
                new Box(2, 3, 3)
            };

            var result = FindTallestStack.Find(boxes);

            Assert.AreEqual(3, result.Sum(b => b.Height));
        }
    }
}
