using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CsFx.CtCI.Moderate;

namespace CsFxCtCITests.Moderate {
    [TestClass]
    public class ParseNoStopTextTests {
        [TestMethod]
        public void Test() {
            var sentence = "thisisbillytesting";
            var dictionary = new HashSet<string> {
                "this", "is", "testing"
            };

            var result = ParseNoStopText.Parse(sentence, dictionary, 0, 0);
            Assert.AreEqual(5, result);
        }
    }
}
