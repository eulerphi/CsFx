using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.Hard;

namespace CsFxCtCITests.Hard {
    [TestClass]
    public class FindSmallestSubsetTests {
        [TestMethod]
        public void Test() {
            var input = new int[] { 5, 3, 2, 6, 9, 7 };
            var result = FindSmallestSubset.Find(input, 3);
            CollectionAssert.AreEquivalent(new int[] { 2, 3, 5 }, result);
        }
    }
}
