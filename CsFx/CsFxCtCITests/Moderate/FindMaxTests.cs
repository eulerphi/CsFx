using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.Moderate;

namespace CsFxCtCITests.Moderate {
    [TestClass]
    public class FindMaxTests {
        [TestMethod]
        public void Test_Same() {
            Assert.AreEqual(0, FindMax.Max(0, 0));
        }

        [TestMethod]
        public void Test_BothPositive() {
            Assert.AreEqual(10, FindMax.Max(5, 10));
            Assert.AreEqual(10, FindMax.Max(10, 5));
        }

        [TestMethod]
        public void Test_BothNegative() {
            Assert.AreEqual(-5, FindMax.Max(-5, -10));
            Assert.AreEqual(-5, FindMax.Max(-10, -5));
        }

        [TestMethod]
        public void Test_PositiveAndNegative() {
            Assert.AreEqual(1, FindMax.Max(-5, 1));
            Assert.AreEqual(1, FindMax.Max(1, -5));
        }

        [TestMethod]
        public void Test_Overflow() {
            var a = Int32.MaxValue - 2;
            Assert.AreEqual(a, FindMax.Max(a, -5));
        }
    }
}
