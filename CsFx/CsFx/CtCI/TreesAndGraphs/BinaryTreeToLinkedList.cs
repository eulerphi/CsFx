using CsFx.CtCI.LinkedLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.TreesAndGraphs {
    class BinaryTreeToLinkedList {
        public static IEnumerable<LinkedListNode> ToLinkedListByLevel(
            BinaryTreeNode root) {

            var currentLevel = new List<BinaryTreeNode>();

            if (root != null) {
                currentLevel.Add(root);
            }

            while (currentLevel.Any()) {
                yield return ToLinkedList(currentLevel);
                currentLevel = currentLevel.SelectMany(GetChildren).ToList();
            }
        }

        private static LinkedListNode ToLinkedList(IList<BinaryTreeNode> treeNodes) {
            LinkedListNode head = null;
            LinkedListNode previous = null;
            foreach (var treeNode in treeNodes) {
                var listNode = new LinkedListNode { Value = treeNode.Value };
                if (head == null) {
                    head = listNode;
                }

                if (previous != null) {
                    previous.Next = listNode;
                }

                previous = listNode;
            }

            return head;
        }

        private static IEnumerable<BinaryTreeNode> GetChildren(BinaryTreeNode node) {
            if (node.Left != null) {
                yield return node.Left;
            }

            if (node.Right != null) {
                yield return node.Right;
            }
        }
    }
}
