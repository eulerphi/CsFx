using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.ArraysAndStrings;

namespace CsFxCtCITests.ArraysAndStrings {
    [TestClass]
    public class Problem4Tests {
        [TestMethod]
        public void Test() {
            var str = new char[100];
            str[0] = 'a';
            str[1] = ' ';
            str[2] = 'c';
            str[3] = ' ';

            new Problem4().Solution1(str, 5);
            var result = new string(str.Take(8).ToArray());

            Assert.AreEqual("a%20c%20", result);
        }
    }
}
