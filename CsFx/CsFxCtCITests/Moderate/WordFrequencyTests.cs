using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.Moderate;

namespace CsFxCtCITests.Moderate {
    [TestClass]
    public class WordFrequencyTests {
        [TestMethod]
        public void Test() {
            var book = new string[] {
                "cat", "dog", "dog", "bill", "dog", "cat"
            };

            var sut = new WordFrequency(book);

            Assert.AreEqual(3, sut.Count("dog"));
            Assert.AreEqual(2, sut.Count("cat"));
            Assert.AreEqual(1, sut.Count("bill"));
            Assert.AreEqual(0, sut.Count("fred"));
        }
    }
}
