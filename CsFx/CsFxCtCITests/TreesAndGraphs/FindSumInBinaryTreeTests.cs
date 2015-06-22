using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.TreesAndGraphs;
using System.Collections.Generic;

namespace CsFxCtCITests.TreesAndGraphs {
    [TestClass]
    public class FindSumInBinaryTreeTests {
        [TestMethod]
        public void TestTree() {
            var root = new BinaryTreeNode {
                Value = 8,
                Left = new BinaryTreeNode {
                    Value = -4,
                    Left = new BinaryTreeNode {
                        Value = -5,
                        Right = new BinaryTreeNode {
                            Value = 9
                        }
                    }
                },
                Right = new BinaryTreeNode {
                    Value = 0,
                    Right = new BinaryTreeNode {
                        Value = 1,
                        Left = new BinaryTreeNode {
                            Value = -2,
                            Right = new BinaryTreeNode {
                                Value = 10
                            }
                        }
                    }
                }
            };

            var expected = new List<int[]> {
                new int[] { 8 },
                new int[] { 8, -4, -5, 9 },
                new int[] { 8, 0 },
                new int[] { -2, 10 }
            };

            var result = FindSumInBinaryTree.FindSum(root, 8);

            Assert.AreEqual(expected.Count, result.Length);

            for (var i = 0; i < expected.Count; i++) {
                CollectionAssert.AreEqual(expected[i], result[i]);
            }
        }
    }
}
