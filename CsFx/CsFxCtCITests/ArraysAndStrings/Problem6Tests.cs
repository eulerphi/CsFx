using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.ArraysAndStrings;

namespace CsFxCtCITests.ArraysAndStrings {
    [TestClass]
    public class Problem6Tests {
        [TestMethod]
        public void Test1() {
            var matrix = new int[][] {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 }
            };

            var expected = new int[][] {
                new int[] { 7, 4, 1 },
                new int[] { 8, 5, 2},
                new int[] { 9, 6, 3 }
            };
            
            Problem6.Solution(matrix, 3);

            for (var i = 0; i < expected.Length; i++) {
                for (var j = 0; j < expected[i].Length; j++) {
                    Assert.AreEqual(expected[i][j], matrix[i][j]);
                }
            }
        }

        [TestMethod]
        public void Test2() {
            var matrix = new int[][] {
                new int[] { 1,  2,  3,  4 },
                new int[] { 5,  6,  7,  8 },
                new int[] { 9,  10, 11, 12 },
                new int[] { 13, 14, 15, 16 }
            };

            var expected = new int[][] {
                new int[] { 13, 9,  5, 1 },
                new int[] { 14, 10, 6, 2 },
                new int[] { 15, 11, 7, 3 },
                new int[] { 16, 12, 8, 4 }
            };
            
            Problem6.Solution(matrix, 4);

            for (var i = 0; i < expected.Length; i++) {
                for (var j = 0; j < expected[i].Length; j++) {
                    Assert.AreEqual(expected[i][j], matrix[i][j]);
                }
            }
        }
    }
}
