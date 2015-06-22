using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.SortingAndSearching;

namespace CsFxCtCITests.SortingAndSearching {
    [TestClass]
    public class MergeTwoSortedArraysTests {
        [TestMethod]
        public void Test() {
            var a = new int[] { 4, 5, 0, 0, 0, 0 };
            MergeTwoSortedArrays.Merge(a, new int[] { 1, 2, 3 }, 2);

            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 0 }, a);
        }
    }
}
