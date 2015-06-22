using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.RecursionAndDynamicProgramming;

namespace CsFxCtCITests.RecursionAndDynamicProgramming {
    [TestClass]
    public class CountNumberOfWaysUpStairsTests {
        [TestMethod]
        public void TestNegativeNumberOfStairs() {
            Assert.AreEqual(0, CountNumberOfWaysUpStairs.Count(-1));
            Assert.AreEqual(0, CountNumberOfWaysUpStairs.CountMemo(-1));
        }

        [TestMethod]
        public void TestZeroNumberOfStairs() {
            Assert.AreEqual(1, CountNumberOfWaysUpStairs.Count(0));
            Assert.AreEqual(1, CountNumberOfWaysUpStairs.CountMemo(0));
        }

        [TestMethod]
        public void Test() {
            Assert.AreEqual(2555757, CountNumberOfWaysUpStairs.Count(25));
            Assert.AreEqual(2555757, CountNumberOfWaysUpStairs.CountMemo(25));
        }
    }
}
