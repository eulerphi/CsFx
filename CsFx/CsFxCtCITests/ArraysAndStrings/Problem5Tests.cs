using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsFx.CtCI.ArraysAndStrings;

namespace CsFxCtCITests.ArraysAndStrings {
    [TestClass]
    public class Problem5Tests {
        [TestMethod]
        public void Test() {
            var p = new Problem5();
            Assert.AreEqual("a2b1c5a3",  p.Solution1("aabcccccaaa"));
            Assert.AreEqual("abc", p.Solution1("abc"));
        }
    }
}
