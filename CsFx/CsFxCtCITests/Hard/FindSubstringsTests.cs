using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.Hard;

namespace CsFxCtCITests.Hard {
    [TestClass]
    public class FindSubstringsTests {
        [TestMethod]
        public void Test() {
            var s = "banana";
            var ts = new string[] {
                "nana", "ban", "ana", "dana"
            };

            var expected = new string[] {
                "nana", "ban", "ana"
            };
            var result = FindSubstrings.Find(s, ts).ToList();

            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}
