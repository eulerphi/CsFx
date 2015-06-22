using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.TreesAndGraphs;

namespace CsFxCtCITests.TreesAndGraphs {
    [TestClass]
    public class FindInorderSuccessorTests {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullNode() {
            FindInorderSuccessor.FindSuccessor(null);
        }

        [TestMethod]
        public void TestParentEqualToNull_NullRight() {
            var node = new BinaryTreeNodeWithParent {
                Right = null
            };

            var result = FindInorderSuccessor.FindSuccessor(node);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void TestHasRightSubtree_LeafRight() {
            var node = new BinaryTreeNodeWithParent {
                Right = new BinaryTreeNodeWithParent()
            };

            var result = FindInorderSuccessor.FindSuccessor(node);
            Assert.AreEqual(node.Right, result);
        }

        [TestMethod]
        public void TestHasRightSubtree_LeftMostRight() {
            var expected = new BinaryTreeNodeWithParent();

            var node = new BinaryTreeNodeWithParent {
                Right = new BinaryTreeNodeWithParent {
                    Left = new BinaryTreeNodeWithParent {
                        Left = expected
                    }
                }
            };

            var result = FindInorderSuccessor.FindSuccessor(node);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestFindAncestor_Parent() {
            var parent = new BinaryTreeNodeWithParent {
                Left = new BinaryTreeNodeWithParent()
            };

            var result = FindInorderSuccessor.FindSuccessor(parent.Left);
            Assert.AreEqual(parent, result);
        }

        [TestMethod]
        public void TestFindAncestor_ParentParent() {
            var node = new BinaryTreeNodeWithParent();

            var grandparent = new BinaryTreeNodeWithParent {
                Left = new BinaryTreeNodeWithParent {
                    Right = node
                }
            };

            var result = FindInorderSuccessor.FindSuccessor(node);
            Assert.AreEqual(grandparent, result);
        }

        [TestMethod]
        public void TestFindAncestor_NodeIsLastElement() {
            var node = new BinaryTreeNodeWithParent();

            var grandparent = new BinaryTreeNodeWithParent {
                Right = new BinaryTreeNodeWithParent {
                    Right = node
                }
            };

            var result = FindInorderSuccessor.FindSuccessor(node);
            Assert.AreEqual(null, result);
        }
    }
}
