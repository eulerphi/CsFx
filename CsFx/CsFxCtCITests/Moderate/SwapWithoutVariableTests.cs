using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.Moderate;

namespace CsFxCtCITests.Moderate {
    [TestClass]
    public class SwapWithoutVariableTests {
        [TestMethod]
        public void Test() {
            var a = 14;
            var b = 21;

            SwapWithoutVariable.Swap(ref a, ref b);
            Assert.AreEqual(21, a);
            Assert.AreEqual(14, b);
        }
    }
}
