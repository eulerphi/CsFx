using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.TreesAndGraphs;

namespace CsFxCtCITests.TreesAndGraphs {
    [TestClass]
    public class BinaryTreeFromSortedArrayTests {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullArray() {
            BinaryTreeFromSortedArray.ToBinaryTree(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUnsortedArray() {
            BinaryTreeFromSortedArray.ToBinaryTree(new int[] { 1, 2, 0 });
        }

        [TestMethod]
        public void TestZeroLengthArray() {
            var result = BinaryTreeFromSortedArray.ToBinaryTree(new int[0]);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void TestOneLengthArray() {
            var result = BinaryTreeFromSortedArray.ToBinaryTree(
                new int[] { 1 });
            Assert.AreEqual(1, result.Value);
            AssertIsLeafNode(result);
        }

        [TestMethod]
        public void TestTwoLengthArray() {
            var result = BinaryTreeFromSortedArray.ToBinaryTree(
                new int[] { 1, 2 });
            Assert.AreEqual(1, result.Value);

            Assert.AreEqual(2, result.Right.Value);
            AssertIsLeafNode(result.Right);

            Assert.AreEqual(null, result.Left);
        }

        [TestMethod]
        public void TestThreeLengthArray() {
            var result = BinaryTreeFromSortedArray.ToBinaryTree(
                new int[] { 1, 2, 3 });
            Assert.AreEqual(2, result.Value);

            Assert.AreEqual(1, result.Left.Value);
            AssertIsLeafNode(result.Left);

            Assert.AreEqual(3, result.Right.Value);
            AssertIsLeafNode(result.Right);
        }

        [TestMethod]
        public void TestLargeArray() {
            var result = BinaryTreeFromSortedArray.ToBinaryTree(
                new int[] { 1, 2, 3, 4, 5, 6 });

            Assert.AreEqual(3, result.Value);

            Assert.AreEqual(1, result.Left.Value);
            Assert.AreEqual(2, result.Left.Right.Value);

            Assert.AreEqual(5, result.Right.Value);
            Assert.AreEqual(4, result.Right.Left.Value);
            Assert.AreEqual(6, result.Right.Right.Value);
        }

        private void AssertIsLeafNode(BinaryTreeNode node) {
            Assert.AreEqual(null, node.Left);
            Assert.AreEqual(null, node.Right);
        }
    }
}
