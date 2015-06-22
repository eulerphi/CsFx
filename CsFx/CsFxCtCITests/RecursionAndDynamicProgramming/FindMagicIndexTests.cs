using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.RecursionAndDynamicProgramming;

namespace CsFxCtCITests.RecursionAndDynamicProgramming {
    [TestClass]
    public class FindDistinctMagicIndexTests {
        [TestMethod]
        public void TestZeroLengthArray() {
            Assert.AreEqual(-1, FindMagicIndex.FindDistinct(new int[0]));
        }

        [TestMethod]
        public void TestOneLengthArray() {
            Assert.AreEqual(0, FindMagicIndex.FindDistinct(new int[] { 0 }));
            Assert.AreEqual(-1, FindMagicIndex.FindDistinct(new int[] { 1 }));
        }

        [TestMethod]
        public void TestTwoLengthArray() {
            Assert.AreEqual(1, FindMagicIndex.FindDistinct(new int[] { -10, 1 }));
            Assert.AreEqual(0, FindMagicIndex.FindDistinct(new int[] { 0, 2 }));
            Assert.AreEqual(1, FindMagicIndex.FindDistinct(new int[] { -1, 1 }));
        }

        [TestMethod]
        public void TestThreeLengthArray() {
            Assert.AreEqual(2, FindMagicIndex.FindDistinct(new int[] { -1, 0, 2 }));
        }
    }

    [TestClass]
    public class FindMagicIndexTests {
        [TestMethod]
        public void TestZeroLengthArray() {
            Assert.AreEqual(-1, FindMagicIndex.Find(new int[0]));
        }

        [TestMethod]
        public void TestOneLengthArray() {
            Assert.AreEqual(0, FindMagicIndex.Find(new int[] { 0 }));
            Assert.AreEqual(-1, FindMagicIndex.Find(new int[] { 1 }));
        }

        [TestMethod]
        public void TestTwoLengthArray() {
            Assert.AreEqual(1, FindMagicIndex.Find(new int[] { -10, 1 }));
            Assert.AreEqual(0, FindMagicIndex.Find(new int[] { 0, 2 }));
            Assert.AreEqual(1, FindMagicIndex.Find(new int[] { -1, 1 }));
        }

        [TestMethod]
        public void Test() {
            Assert.AreEqual(2, FindMagicIndex.Find(
                new int[] { -10, -5, 2, 2, 2, 2, 3, 4, 4, 7, 9, 12, 13 }));
        }
    }
}
