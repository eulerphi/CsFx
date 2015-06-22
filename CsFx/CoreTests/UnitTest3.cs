using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.Core;

namespace CsFxCoreTests {
    [TestClass]
    public class UnitTest3 {
        [TestMethod]
        public void Test() {
            var a = new int[] { 3, 2, 5, 4, 7, 2 };
            var actual = CountInversions.Count(a);
            Assert.AreEqual(6, actual);
        }
    }
}
