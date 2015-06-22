using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.Moderate;

namespace CsFxCtCITests.Moderate {
    [TestClass]
    public class ConvertIntToPhraseTests {
        [TestMethod]
        public void Test() {
            Assert.AreEqual("One Hundred Forty Two", ConvertIntToPhrase.Convert(142));
            Assert.AreEqual(
                "Negative One Hundred Million Fifteen",
                ConvertIntToPhrase.Convert(-100000015));
        }
    }
}
