using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.Moderate;

namespace CsFxCtCITests.Moderate {
    [TestClass]
    public class FindNumberOfTrailingZerosTests {
        [TestMethod]
        public void Test() {
            var data = new Tuple<int, int>[] {
                Tuple.Create(4, 0),
                Tuple.Create(5, 1),
                Tuple.Create(7, 1),
                Tuple.Create(10, 2),
                Tuple.Create(15, 3),
                Tuple.Create(20, 4),
            };

            foreach (var t in data) {
                Assert.AreEqual(t.Item2, FindNumberOfTrailingZeros.FindForFactorial(t.Item1));
            }
        }
    }
}
