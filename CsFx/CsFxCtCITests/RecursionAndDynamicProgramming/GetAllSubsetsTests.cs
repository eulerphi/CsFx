using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CsFx.CtCI.RecursionAndDynamicProgramming;

namespace CsFxCtCITests.RecursionAndDynamicProgramming {
    [TestClass]
    public class GetAllSubsetsTests {
        [TestMethod]
        public void Test() {
            var set = new List<int> { 1, 2, 3 };
            var subsets = GetAllSubsets.ToPowerSet(set).ToList();

            var expected = new List<List<int>> {
                new List<int> { },
                new List<int> { 1 },
                new List<int> { 2 },
                new List<int> { 3 },
                new List<int> { 1, 2 },
                new List<int> { 1, 3 },
                new List<int> { 2, 3 },
                new List<int> { 1, 2, 3},
            };

            var toBitMask = CreateToBitMask(set);
            CollectionAssert.AreEquivalent(
                expected.Select(toBitMask).ToList(),
                subsets.Select(toBitMask).ToList());
        }

        private Func<IList<int>, int> CreateToBitMask(IList<int> set) {
            var map = new Dictionary<int, int>();
            for (var i = 0; i < set.Count; i++) {
                map.Add(set[i], 1 << i);
            }

            return subset => subset.Select(x => map[x]).Sum();
        }
    }
}
