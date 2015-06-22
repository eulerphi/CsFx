using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.RecursionAndDynamicProgramming;

namespace CsFxCtCITests.RecursionAndDynamicProgramming {
    [TestClass]
    public class CountNumberOfWaysSumCentsTests {
        [TestMethod]
        public void Test() {
            Assert.AreEqual(242, CountNumberOfWaysSumCents.Count(100));
        }
    }
}
