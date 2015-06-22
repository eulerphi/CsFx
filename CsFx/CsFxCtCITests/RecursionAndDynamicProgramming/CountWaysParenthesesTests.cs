using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.RecursionAndDynamicProgramming;

namespace CsFxCtCITests.RecursionAndDynamicProgramming {
    [TestClass]
    public class CountWaysParenthesesTests {
        [TestMethod]
        public void TestSingleOp_ValidExpressions() {
            var expressions = new string[] {
                "1&1",
                "1|1",
                "1|0",
                "0|1",
                "1^0",
                "0^1"
            };

            foreach (var e in expressions) {
                Assert.AreEqual(1, CountWaysParentheses.CountTrue(e), "Expression: " + e);
                Assert.AreEqual(0, CountWaysParentheses.CountFalse(e), "Expression: " + e);
            }
        }

        [TestMethod]
        public void TestSingleOp_InvalidExpressions() {
            var expressions = new string[] {
                "1&0",
                "1&0",
                "0&1",
                "0|0",
                "1^1",
                "0^0"
            };

            foreach (var e in expressions) {
                Assert.AreEqual(0, CountWaysParentheses.CountTrue(e), "Expression: " + e);
                Assert.AreEqual(1, CountWaysParentheses.CountFalse(e), "Expression: " + e);
            }
        }

        [TestMethod]
        public void Test() {
            var expression = "1^0|0|1";
            Assert.AreEqual(3, CountWaysParentheses.CountTrue(expression));
            Assert.AreEqual(2, CountWaysParentheses.CountFalse(expression));
        }
    }
}
