using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CsFx.CtCI.SortingAndSearching;

namespace CsFxCtCITests.SortingAndSearching {
    [TestClass]
    public class GetRankFromStreamTests {
        [TestMethod]
        public void Test() {
            var sut = new GetRankFromStream();
            
            var values = new List<int> { 3, 5, 1, 2, 6, 8, 9, 4 };
            foreach (var value in values) {
                sut.Track(value);
            }

            var sortedValues = values.OrderBy(v => v).ToList();
            for (var i = 0; i < sortedValues.Count; i++) {
                Assert.AreEqual(i + 1, sut.GetRank(sortedValues[i]));
            }
        }
    }
}
