using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CsFx.CtCI.Moderate;

namespace CsFxCtCITests.Moderate {
    [TestClass]
    public class Rand7Tests {
        [TestMethod]
        public void Test() {
            var values = Enumerable
                .Range(0, 100)
                .Select(_ => Rand7.Next());

            foreach (var v in values) {
                if (v < 0 || v > 6) {
                    Assert.Fail("Out of range");
                }
            }
        }
    }
}
