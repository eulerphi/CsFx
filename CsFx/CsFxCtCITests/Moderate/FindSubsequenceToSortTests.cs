using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.Moderate;
using CsFx.CtCI.Shared;

namespace CsFxCtCITests.Moderate {
    [TestClass]
    public class FindSubsequenceToSortTests {
        [TestMethod]
        public void Test() {
            var result = FindSubsequenceToSort.Find(
                new int[] { 1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19 });

            Assert.AreEqual(new Pair(3, 9), result);
        }

        [TestMethod]
        public void Test2() {
            var result = FindSubsequenceToSort.Find(
                new int[] { 1, 2, 3, 4, 5, 11, 7, 12, 6, 7, 16, 18, 19 });

            Assert.AreEqual(new Pair(5, 9), result);
        }
    }
}
