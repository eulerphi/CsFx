using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.Hard;

namespace CsFxCtCITests.Hard {
    [TestClass]
    public class CountTwosBetweenZeroAndNTests {
        [TestMethod]
        public void TestMethod1() {
            var count = CountTwosBetweenZeroAndN.Count(61523);
        }
    }
}
