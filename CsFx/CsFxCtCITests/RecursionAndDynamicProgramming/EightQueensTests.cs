using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CsFx.CtCI.RecursionAndDynamicProgramming;

namespace CsFxCtCITests.RecursionAndDynamicProgramming {
    [TestClass]
    public class EightQueensTests {
        [TestMethod]
        public void Test() {
            Assert.AreEqual(92, EightQueens.Solve().Count);
        }
    }
}
