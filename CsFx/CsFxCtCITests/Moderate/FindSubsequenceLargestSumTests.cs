using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.Moderate;

namespace CsFxCtCITests.Moderate {
    [TestClass]
    public class FindSubsequenceLargestSumTests {
        [TestMethod]
        public void Test() {
            var a = new int[] { 2, 3, -8, -1, 2, 4, -2, 3 };
            Assert.AreEqual(7, FindSubsequenceLargestSum.Find(a));
        }

        [TestMethod]
        public void TestAllNegative() {
            var a = new int[] { -3, -4, -5 };
            Assert.AreEqual(0, FindSubsequenceLargestSum.Find(a));
        }
    }
}
