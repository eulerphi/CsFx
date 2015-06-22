using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.TreesAndGraphs;

namespace CsFxCtCITests.TreesAndGraphs {
    [TestClass]
    public class IsBinarySearchTreeTests {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullRoot() {
            IsBinarySearchTree.IsBST(null);
        }

        [TestMethod]
        public void TestOneElementTree() {
            var result = IsBinarySearchTree.IsBST(
                new BinaryTreeNode { Value = 2 });

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestLeftChild_EqualToParent() {
            var root = new BinaryTreeNode {
                Value = 20,
                Left = new BinaryTreeNode {
                    Value = 20
                }
            };

            var result = IsBinarySearchTree.IsBST(root);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestLeftChild_LessThanParent() {
            var root = new BinaryTreeNode {
                Value = 20,
                Left = new BinaryTreeNode {
                    Value = 19
                }
            };

            var result = IsBinarySearchTree.IsBST(root);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestLeftChild_GreaterThanParent() {
            var root = new BinaryTreeNode {
                Value = 20,
                Left = new BinaryTreeNode {
                    Value = 21
                }
            };

            var result = IsBinarySearchTree.IsBST(root);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestRightChild_EqualToParent() {
            var root = new BinaryTreeNode {
                Value = 20,
                Right = new BinaryTreeNode {
                    Value = 20
                }
            };

            var result = IsBinarySearchTree.IsBST(root);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestRightChild_LessThanParent() {
            var root = new BinaryTreeNode {
                Value = 20,
                Right = new BinaryTreeNode {
                    Value = 19
                }
            };

            var result = IsBinarySearchTree.IsBST(root);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestRightChild_GreaterThanParent() {
            var root = new BinaryTreeNode {
                Value = 20,
                Right = new BinaryTreeNode {
                    Value = 21
                }
            };

            var result = IsBinarySearchTree.IsBST(root);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestTree_Green() {
            var root = new BinaryTreeNode {
                Value = 20,
                Left = new BinaryTreeNode {
                    Value = 19,
                    Left = new BinaryTreeNode {
                        Value = 18,
                        Right = new BinaryTreeNode {
                            Value = 19
                        }
                    }
                },
                Right = new BinaryTreeNode {
                    Value = 22,
                    Left = new BinaryTreeNode {
                        Value = 21 
                    },
                    Right = new BinaryTreeNode {
                        Value = 100,
                        Left = new BinaryTreeNode {
                            Value = 23
                        }
                    }
                }
            };

            var result = IsBinarySearchTree.IsBST(root);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestTree_Red() {
            var root = new BinaryTreeNode {
                Value = 20,
                Left = new BinaryTreeNode {
                    Value = 19,
                    Left = new BinaryTreeNode {
                        Value = 18,
                        Right = new BinaryTreeNode {
                            Value = 20
                        }
                    }
                },
                Right = new BinaryTreeNode {
                    Value = 22,
                    Left = new BinaryTreeNode {
                        Value = 21 
                    },
                    Right = new BinaryTreeNode {
                        Value = 100,
                        Left = new BinaryTreeNode {
                            Value = 23
                        }
                    }
                }
            };

            var result = IsBinarySearchTree.IsBST(root);

            Assert.IsFalse(result);
        }
    }
}
