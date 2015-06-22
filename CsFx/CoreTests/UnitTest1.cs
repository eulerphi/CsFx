using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.Core;

namespace CsFxCoreTests {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void Test() {
            var actual = new int[] { 3, 2, 5, 4, 7, 2 };
            MergeSort.Sort(actual);

            var expected = new int[] { 2, 2, 3, 4, 5, 7 };
            for (var i = 0; i < actual.Length; i++) {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
