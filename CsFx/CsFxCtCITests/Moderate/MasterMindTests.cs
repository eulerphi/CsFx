using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.Moderate;

namespace CsFxCtCITests.Moderate {
    [TestClass]
    public class MasterMindTests {
        [TestMethod]
        public void Test() {
            var guess = new MasterMindColor[] {
                MasterMindColor.Green,
                MasterMindColor.Green,
                MasterMindColor.Red,
                MasterMindColor.Red
            };

            var solution = new MasterMindColor[] {
                MasterMindColor.Red,
                MasterMindColor.Green,
                MasterMindColor.Blue,
                MasterMindColor.Yellow
            };

            var expected = new MasterMindResult(1, 1);

            Assert.AreEqual(expected, MasterMind.Check(guess, solution));
        }
    }
}
