using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.TreesAndGraphs;
using CsFx.CtCI.LinkedLists;
using System.Collections.Generic;

namespace CsFxCtCITests.TreesAndGraphs {
    [TestClass]
    public class BinaryTreeToLinkedListTests {
        [TestMethod]
        public void TestNullRoot() {
            var result = BinaryTreeToLinkedList
                .ToLinkedListByLevel(null)
                .ToList();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void TestSingleLevel() {
            var result = BinaryTreeToLinkedList
                .ToLinkedListByLevel(new BinaryTreeNode { Value = 42 })
                .ToList();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(42, result[0].Value);
            Assert.AreEqual(null, result[0].Next);
        }

        [TestMethod]
        public void TestMultipleLevel() {
            var tree = new BinaryTreeNode {
                Value = 11,
                Left = new BinaryTreeNode {
                    Value = 21,
                    Left = new BinaryTreeNode {
                        Value = 31,
                        Left = new BinaryTreeNode {
                            Value = 41
                        },
                        Right = new BinaryTreeNode {
                            Value = 42
                        }
                    }
                },
                Right = new BinaryTreeNode {
                    Value = 22,
                    Left = new BinaryTreeNode {
                        Value = 32,
                        Left = new BinaryTreeNode {
                            Value = 43
                        },
                        Right = new BinaryTreeNode {
                            Value = 44
                        }
                    },
                    Right = new BinaryTreeNode {
                        Value = 33,
                        Left = new BinaryTreeNode {
                            Value = 45
                        },
                        Right = new BinaryTreeNode {
                            Value = 46
                        }
                    }
                }
            };

            var result = BinaryTreeToLinkedList
                .ToLinkedListByLevel(tree)
                .ToList();

            Assert.AreEqual(4, result.Count);

            CollectionAssert.AreEqual(
                new int[] { 11 },
                ToArray(result[0]));

            CollectionAssert.AreEqual(
                new int[] { 21, 22 },
                ToArray(result[1]));

            CollectionAssert.AreEqual(
                new int[] { 31, 32, 33 },
                ToArray(result[2]));

            CollectionAssert.AreEqual(
                new int[] { 41, 42, 43, 44, 45, 46 },
                ToArray(result[3]));
        }

        private List<int> ToArray(LinkedListNode head) {
            var list = new List<int>();
            while (head != null) {
                list.Add(head.Value);
                head = head.Next;
            }

            return list;
        }
    }
}
