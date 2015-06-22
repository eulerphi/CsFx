using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.Hard;

namespace CsFxCtCITests.Hard {
    [TestClass]
    public class FindDistanceBetweenWordsTests {
        [TestMethod]
        public void Test() {
            var words = new string[] {
                "the", "quick", "brown", "fox", "jumped", "over", "the", "lazy", "dog" 
            };

            Assert.AreEqual(1, FindDistanceBetweenWords.Find(words, "quick", "the"));
            Assert.AreEqual(5, FindDistanceBetweenWords.Find(words, "fox", "dog"));
        }
    }
}
