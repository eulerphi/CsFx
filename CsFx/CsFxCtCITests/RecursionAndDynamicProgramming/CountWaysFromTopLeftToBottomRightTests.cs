using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.RecursionAndDynamicProgramming;
using System.Collections.Generic;
using CsFx.CtCI.Shared;

namespace CsFxCtCITests.RecursionAndDynamicProgramming {
    [TestClass]
    public class CountWaysFromTopLeftToBottomRightTests {
        [TestMethod]
        public void TestCount() {
            Assert.AreEqual(20, CountWaysFromTopLeftToBottomRight.Count(3, 3));
        }

        [TestMethod]
        public void TestFindPath_Red() {
            var offlimits = new HashSet<Point>();
            offlimits.Add(new Point(1, 0));
            offlimits.Add(new Point(0, 1));
            Point[] path;
            var result = CountWaysFromTopLeftToBottomRight.FindPath(
                1, 1, (x, y) => !offlimits.Contains(new Point(x, y)), out path);

            Assert.IsFalse(result);
            Assert.AreEqual(0, path.Length);
        }

        [TestMethod]
        public void TestFindPath_Green() {
            var offlimits = new HashSet<Point>();
            offlimits.Add(new Point(1, 0));
            offlimits.Add(new Point(0, 2));
            Point[] path;
            var result = CountWaysFromTopLeftToBottomRight.FindPath(
                2, 2, (x, y) => !offlimits.Contains(new Point(x, y)), out path);

            Assert.IsTrue(result);
            Assert.AreEqual(5, path.Length);
        }
    }
}
