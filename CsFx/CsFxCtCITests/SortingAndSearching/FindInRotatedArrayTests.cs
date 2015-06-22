using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.SortingAndSearching;

namespace CsFxCtCITests.SortingAndSearching {
    [TestClass]
    public class FindInRotatedArrayTests {
        [TestMethod]
        public void Test_ValueNotThere() {
            var a = new int[] { 1, 2, 3, 5, 0 };
            Assert.AreEqual(-1, FindInRotatedArray.Find(a, 42));
        }

        [TestMethod]
        public void TestLeftSideSorted_ValueOnLeft() {
            var a = new int[] { 1, 2, 3, 5, 0 };
            Assert.AreEqual(0, FindInRotatedArray.Find(a, 1));
        }

        [TestMethod]
        public void TestLeftSideSorted_ValueOnRight() {
            var a = new int[] { 1, 2, 3, 5, 0 };
            Assert.AreEqual(3, FindInRotatedArray.Find(a, 5));
        }

        [TestMethod]
        public void TestRightSideSorted_ValueOnLeft() {
            var a = new int[] { 5, 0, 1, 2, 3 };
            Assert.AreEqual(1, FindInRotatedArray.Find(a, 0));
        }

        [TestMethod]
        public void TestRightSideSorted_ValueOnRight() {
            var a = new int[] { 5, 0, 1, 2, 3 };
            Assert.AreEqual(3, FindInRotatedArray.Find(a, 2));
        }

        [TestMethod]
        public void TestRightSideSorted_ValueOnRight_Case2() {
            var a = new int[] { 1, 0, 1, 2, 3 };
            Assert.AreEqual(3, FindInRotatedArray.Find(a, 2));
        }

        [TestMethod]
        public void TestIndeterminate_ValueOnLeft() {
            var a = new int[] { 1, 0, 1, 1, 1, 1 };
            Assert.AreEqual(1, FindInRotatedArray.Find(a, 0));
        }

        [TestMethod]
        public void TestIndeterminate_ValueOnRight() {
            var a = new int[] { 1, 1, 1, 0, 1, 1 };
            Assert.AreEqual(3, FindInRotatedArray.Find(a, 0));
        }
    }
}
