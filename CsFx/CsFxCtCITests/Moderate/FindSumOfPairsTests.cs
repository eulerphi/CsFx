using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.Moderate;
using CsFx.CtCI.Shared;

namespace CsFxCtCITests.Moderate {
    [TestClass]
    public class FindSumOfPairsTests {
        [TestMethod]
        public void Test() {
            var a = new int[] {
                1, 3, 2, 8, 10, 6
            };

            var expected = new Pair[] {
                new Pair(1, 8),
                new Pair(3, 6)
            };

            var result = FindSumOfPairs.Find(a, 9).ToList();
            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}
