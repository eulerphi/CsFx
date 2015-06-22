using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.Hard;

namespace CsFxCtCITests.Hard {
    [TestClass]
    public class RandomFromPoolTests {
        [TestMethod]
        public void Test() {
            var a = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            var expected = new int[] { 7, 6, 3, 2, 4, 5, 1 };

            var result = RandomFromPool.PickRandomly(a, 7, 50000);
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
