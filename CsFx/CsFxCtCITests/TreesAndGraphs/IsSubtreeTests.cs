using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.TreesAndGraphs;

namespace CsFxCtCITests.TreesAndGraphs {
    [TestClass]
    public class IsSubtreeTests {
        [TestMethod]
        public void TestNullParent() {
            Assert.IsFalse(IsSubtree.Check(null, new BinaryTreeNode()));
        }

        [TestMethod]
        public void TestNullChild() {
            Assert.IsTrue(IsSubtree.Check(new BinaryTreeNode(), null));
        }

        [TestMethod]
        public void TestPartialMatch() {
            var parent = new BinaryTreeNode {
                Value = 5,
                Left = new BinaryTreeNode {
                    Value = 42,
                    Left = new BinaryTreeNode {
                        Value = 43
                    }
                },
                Right = new BinaryTreeNode {
                    Value = 42,
                    Right = new BinaryTreeNode {
                        Value = 43
                    }
                }
            };

            var child = new BinaryTreeNode {
                Value = 42,
                Left = new BinaryTreeNode {
                    Value = 43
                },
                Right = new BinaryTreeNode {
                    Value = 43
                }
            };

            var result = IsSubtree.Check(parent, child);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMatch() {
            var parent = new BinaryTreeNode {
                Value = 5,
                Left = new BinaryTreeNode {
                    Value = 42,
                    Left = new BinaryTreeNode {
                        Value = 43
                    }
                },
                Right = new BinaryTreeNode {
                    Value = 42,
                    Right = new BinaryTreeNode {
                        Value = 42,
                        Left = new BinaryTreeNode {
                            Value = 43
                        },
                        Right = new BinaryTreeNode {
                            Value = 43
                        }
                    }
                }
            };

            var child = new BinaryTreeNode {
                Value = 42,
                Left = new BinaryTreeNode {
                    Value = 43
                },
                Right = new BinaryTreeNode {
                    Value = 43
                }
            };

            var result = IsSubtree.Check(parent, child);
            Assert.IsTrue(result);
        }
    }
}
