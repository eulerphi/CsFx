using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.ArraysAndStrings;

namespace CsFxCtCITests {
    [TestClass]
    public class Problem2Tests {
        [TestMethod]
        public void Test() {
            var str = "abc de\0";
            var value = new char[str.Length];
            for (var i = 0; i < str.Length; i++) {
                value[i] = str[i];
            }

            new Problem2().Solution1(value);
            var result = new string(value.Take(str.Length - 1).ToArray());
            Assert.AreEqual("ed cba", result);
        }
    }
}
