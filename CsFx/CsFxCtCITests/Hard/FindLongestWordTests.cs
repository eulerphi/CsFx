using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.Hard;

namespace CsFxCtCITests.Hard {
    [TestClass]
    public class FindLongestWordTests {
        [TestMethod]
        public void Test() {
            var words = new string[] {
                "car", "cat", "dog", "catdog", "cardocar"
            };

            var result = FindLongestWord.Find(words);
            Assert.AreEqual("catdog", result);
        }
    }
}
