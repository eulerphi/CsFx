using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.SortingAndSearching;

namespace CsFxCtCITests.SortingAndSearching {
    [TestClass]
    public class FindInArrayWithEmptyStringsTests {
        [TestMethod]
        public void TestAllEmpty() {
            var a = new string[] { String.Empty, String.Empty, String.Empty };
            Assert.AreEqual(-1, FindInArrayWithEmptyStrings.Find(a, "a"));
        }

        [TestMethod]
        public void Test() {
            var a = new string[] { "a", "b", String.Empty, "c", String.Empty, "d" };
            Assert.AreEqual(0, FindInArrayWithEmptyStrings.Find(a, "a"));
            Assert.AreEqual(1, FindInArrayWithEmptyStrings.Find(a, "b"));
            Assert.AreEqual(3, FindInArrayWithEmptyStrings.Find(a, "c"));
            Assert.AreEqual(5, FindInArrayWithEmptyStrings.Find(a, "d"));
        }
    }
}
