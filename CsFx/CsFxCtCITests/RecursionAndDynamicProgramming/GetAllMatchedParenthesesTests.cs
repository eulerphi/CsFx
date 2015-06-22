using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CsFx.CtCI.RecursionAndDynamicProgramming;

namespace CsFxCtCITests.RecursionAndDynamicProgramming {
    [TestClass]
    public class GetAllMatchedParenthesesTests {
        [TestMethod]
        public void Test() {
            var expected = new List<string> {
                "()()()",
                "()(())",
                "(()())",
                "(())()",
                "((()))"
            };

            var result = GetAllMatchedParentheses.Get(3).ToList();
            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}
