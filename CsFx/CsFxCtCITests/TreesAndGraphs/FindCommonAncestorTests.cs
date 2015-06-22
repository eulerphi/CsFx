using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.TreesAndGraphs;

namespace CsFxCtCITests.TreesAndGraphs {
    [TestClass]
    public class FindCommonAncestorTests {
        [TestMethod]
        public void TestRootIsEqualToNode() {
            var root = new BinaryTreeNode();
            Assert.AreEqual(root,
                FindCommonAcestor.Find(root, root, new BinaryTreeNode()));
            Assert.AreEqual(root,
                FindCommonAcestor.Find(root, new BinaryTreeNode(), root));
        }

        [TestMethod]
        public void TestOnDifferentSides() {
            var root = new BinaryTreeNode {
                Left = new BinaryTreeNode(),
                Right = new BinaryTreeNode()
            };

            var result = FindCommonAcestor.Find(root, root.Left, root.Right);
            Assert.AreEqual(root, result);

            result = FindCommonAcestor.Find2(root, root.Left, root.Right);
            Assert.AreEqual(root, result);
            
            result = FindCommonAcestor.Find(root, root.Right, root.Left);
            Assert.AreEqual(root, result);

            result = FindCommonAcestor.Find2(root, root.Right, root.Left);
            Assert.AreEqual(root, result);
        }

        [TestMethod]
        public void TestOnSameSide() {
            var x = new BinaryTreeNode();
            var y = new BinaryTreeNode();
            var ancestor = new BinaryTreeNode {
                Left = x,
                Right = y
            };

            var root = new BinaryTreeNode {
                Left = ancestor,
                Right = new BinaryTreeNode()
            };

            Assert.AreEqual(ancestor, FindCommonAcestor.Find(root, x, y));
            Assert.AreEqual(ancestor, FindCommonAcestor.Find(root, y, x));

            Assert.AreEqual(ancestor, FindCommonAcestor.Find2(root, x, y));
            Assert.AreEqual(ancestor, FindCommonAcestor.Find2(root, y, x));

            // Swap

            root.Left = root.Right;
            root.Right = ancestor;
            
            Assert.AreEqual(ancestor, FindCommonAcestor.Find(root, x, y));
            Assert.AreEqual(ancestor, FindCommonAcestor.Find(root, y, x));

            Assert.AreEqual(ancestor, FindCommonAcestor.Find2(root, x, y));
            Assert.AreEqual(ancestor, FindCommonAcestor.Find2(root, y, x));
        }
    }
}
