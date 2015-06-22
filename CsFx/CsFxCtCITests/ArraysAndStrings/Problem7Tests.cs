using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.ArraysAndStrings;

namespace CsFxCtCITests.ArraysAndStrings {
    [TestClass]
    public class Problem7Tests {
        [TestMethod]
        public void Test() {
            var matrix = new int[][] {
                new int[] { 1,  2,  3,  4 },
                new int[] { 5,  0,  7,  8 },
                new int[] { 9,  0, 11,  0 },
                new int[] { 13, 14, 15, 16 }
            };

            var expected = new int[][] {
                new int[] { 1,  0, 3, 0 },
                new int[] { 0,  0, 0, 0 },
                new int[] { 0,  0, 0, 0 },
                new int[] { 13, 0, 15, 0 }
            };

            Problem7.Solution(matrix);

            for (var i = 0; i < expected.Length; i++) {
                for (var j = 0; j < expected[i].Length; j++) {
                    Assert.AreEqual(expected[i][j], matrix[i][j]);
                }
            }
        }
    }
}
