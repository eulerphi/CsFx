using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.TreesAndGraphs;
using CsFx.CtCI.Moderate;

namespace CsFxCtCITests.Moderate {
    [TestClass]
    public class ConvertTreeToListTests {
        [TestMethod]
        public void Test() {
            var root = new BinaryTreeNode {
                Value = 3,
                Left = new BinaryTreeNode {
                    Value = 1,
                    Right = new BinaryTreeNode {
                        Value = 2
                    }
                },
                Right = new BinaryTreeNode {
                    Value = 5,
                    Left = new BinaryTreeNode {
                        Value = 4
                    }
                }
            };

            var headAndTail = ConvertTreeToList.Convert(root);
            Assert.AreEqual(1, headAndTail.Item1.Value);
            Assert.AreEqual(5, headAndTail.Item2.Value);
        }
    }
}
