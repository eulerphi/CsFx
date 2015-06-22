using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.SortingAndSearching;

namespace CsFxCtCITests.SortingAndSearching {
    [TestClass]
    public class SortAnagramsTests {
        [TestMethod]
        public void Test() {
            var words = new string[] {
                "dog", "cat", "ogd", "tea", "tac", "act", "ate"
            };

            SortAnagrams.Sort(words);

            // fragile...
            var expected = new string[] {
                "dog", "ogd", "cat", "tac", "act", "tea", "ate"
            };

            CollectionAssert.AreEqual(expected, words);
        }
    }
}
