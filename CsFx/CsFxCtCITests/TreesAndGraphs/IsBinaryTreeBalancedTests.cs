using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.TreesAndGraphs;

namespace CsFxCtCITests.TreesAndGraphs {
    [TestClass]
    public class IsBinaryTreeBalancedTests {
        [TestMethod]
        public void TestNullParameter() {
            Assert.IsTrue(IsBinaryTreeBalanced.IsBalanced(null));
        }

        [TestMethod]
        public void TestMultiLevel_Green() {
            var root = new BinaryTreeNode {
                Left = new BinaryTreeNode {
                    Right = new BinaryTreeNode()
                },
                Right = new BinaryTreeNode()
            };

            Assert.IsTrue(IsBinaryTreeBalanced.IsBalanced(root));
        }

        [TestMethod]
        public void TestMultiLevel_RedAtRoot() {
            var root = new BinaryTreeNode {
                Left = new BinaryTreeNode {
                    Right = new BinaryTreeNode {
                        Right = new BinaryTreeNode()
                    }
                },
                Right = new BinaryTreeNode()
            };

            Assert.IsFalse(IsBinaryTreeBalanced.IsBalanced(root));
        }

        [TestMethod]
        public void TestMultiLevel_RedInLeftSubtree() {
            var root = new BinaryTreeNode {
                Left = new BinaryTreeNode {
                    Left = new BinaryTreeNode {
                        Left = new BinaryTreeNode(),
                        Right = new BinaryTreeNode(),
                    }
                },
                Right = new BinaryTreeNode {
                    Left = new BinaryTreeNode {
                        Left = new BinaryTreeNode(),
                        Right = new BinaryTreeNode()
                    },
                    Right = new BinaryTreeNode {
                        Left = new BinaryTreeNode(),
                        Right = new BinaryTreeNode()
                    }
                }
            };

            Assert.IsFalse(IsBinaryTreeBalanced.IsBalanced(root));
        }

        [TestMethod]
        public void TestMultiLevel_RedInRightSubtree() {
            var root = new BinaryTreeNode {
                Left = new BinaryTreeNode {
                    Left = new BinaryTreeNode {
                        Left = new BinaryTreeNode(),
                        Right = new BinaryTreeNode()
                    },
                    Right = new BinaryTreeNode {
                        Left = new BinaryTreeNode(),
                        Right = new BinaryTreeNode()
                    }
                },

                Right = new BinaryTreeNode {
                    Left = new BinaryTreeNode {
                        Left = new BinaryTreeNode(),
                        Right = new BinaryTreeNode(),
                    }
                }
            };

            Assert.IsFalse(IsBinaryTreeBalanced.IsBalanced(root));
        }
    }
}
