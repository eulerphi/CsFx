using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.RecursionAndDynamicProgramming;
using CsFx.CtCI.Shared;

namespace CsFxCtCITests.RecursionAndDynamicProgramming {
    [TestClass]
    public class PaintFillTests {
        [TestMethod]
        public void TestRecursive() {
            var screen = new int[][] {
                new int[] { 2, 1, 1 },
                new int[] { 1, 2, 1 },
                new int[] { 2, 1, 1 },
            };

            PaintFill.FillRecursive(screen, new Point(1, 0), 3);

            CollectionAssert.AreEqual(
                new int[] { 2, 3, 3 },
                screen[0]);

            CollectionAssert.AreEqual(
                new int[] { 1, 2, 3 },
                screen[1]);

            CollectionAssert.AreEqual(
                new int[] { 2, 3, 3 },
                screen[2]);
        }

        [TestMethod]
        public void TestIterative() {
            var screen = new int[][] {
                new int[] { 2, 1, 1 },
                new int[] { 1, 2, 1 },
                new int[] { 2, 1, 1 },
            };

            PaintFill.FillIterative(screen, new Point(1, 0), 3);

            CollectionAssert.AreEqual(
                new int[] { 2, 3, 3 },
                screen[0]);

            CollectionAssert.AreEqual(
                new int[] { 1, 2, 3 },
                screen[1]);

            CollectionAssert.AreEqual(
                new int[] { 2, 3, 3 },
                screen[2]);
        }
    }
}
