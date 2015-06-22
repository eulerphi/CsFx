using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.Hard;

namespace CsFxCtCITests.Hard {
    [TestClass]
    public class ShuffleTests {
        [TestMethod]
        public void TestMethod1() {
            var input = new int[] { 1, 2, 3, 4, 5 };
            Shuffle.Do(input, 5000);

            var expected = new int[] { 5, 1, 2, 3, 4 };
            CollectionAssert.AreEqual(expected, input);
        }
    }
}
