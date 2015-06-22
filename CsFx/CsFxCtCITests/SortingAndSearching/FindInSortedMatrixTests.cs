using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.SortingAndSearching;

namespace CsFxCtCITests.SortingAndSearching {
    [TestClass]
    public class FindInSortedMatrixTests {
        [TestMethod]
        public void Test() {
            var m = new int[][] {
                new int[] { 15, 20, 40, 85 },
                new int[] { 20, 35, 80, 95 },
                new int[] { 30, 55, 95, 105 },
                new int[] { 42, 80, 100, 120 }
            };

            Assert.AreEqual(Tuple.Create(0, 2), FindInSortedMatrix.Find(m, 40));
            Assert.AreEqual(Tuple.Create(2, 3), FindInSortedMatrix.Find(m, 105));
            Assert.AreEqual(Tuple.Create(3, 0), FindInSortedMatrix.Find(m, 42));
        }
    }
}
