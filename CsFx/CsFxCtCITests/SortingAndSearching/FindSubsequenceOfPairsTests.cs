using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.SortingAndSearching;
using System.Collections.Generic;
using CsFx.CtCI.Shared;

namespace CsFxCtCITests.SortingAndSearching {
    [TestClass]
    public class FindSubsequenceOfPairsTests {
        [TestMethod]
        public void Test() {
            var pairs = new List<Pair> {
                new Pair(13, 15),
                new Pair(14, 14),
                new Pair(12, 10),
                new Pair(11, 11),
                new Pair(12, 12)
            };
            
            var result = FindSubsequenceOfPairs.FindLongest(pairs);
        }
    }
}
