using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.TreesAndGraphs {
    class FindInorderSuccessor {
        public static BinaryTreeNodeWithParent FindSuccessor(
            BinaryTreeNodeWithParent node) {

            if (node == null) {
                throw new ArgumentNullException("node");
            }

            return node.Parent == null || node.Right != null
                ? FindLeftMostChild(node.Right)
                : FindLeftSubtreeAncestor(node);
        }

        private static BinaryTreeNodeWithParent FindLeftMostChild(
            BinaryTreeNodeWithParent node) {

            if (node == null) {
                return null;
            }

            while (node.Left != null) {
                node = node.Left;
            }

            return node;
        }

        private static BinaryTreeNodeWithParent FindLeftSubtreeAncestor(
            BinaryTreeNodeWithParent node) {

            var current = node;
            var parent = current.Parent;

            while (parent != null && parent.Left != current) {
                current = parent;
                parent = parent.Parent;
            }

            return parent;
        }
    }
}
