using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.RecursionAndDynamicProgramming;
using System.Collections.Generic;

namespace CsFxCtCITests.RecursionAndDynamicProgramming {
    [TestClass]
    public class GetAllPermutationsTests {
        [TestMethod]
        public void Test() {
            var expected = new List<string> {
                "123",
                "132",
                "213",
                "231",
                "312",
                "321"
            };

            var result = GetAllPermutations.Get("123").ToList();

            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}
