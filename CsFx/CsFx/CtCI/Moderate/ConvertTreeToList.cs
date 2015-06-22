using CsFx.CtCI.LinkedLists;
using CsFx.CtCI.Shared;
using CsFx.CtCI.TreesAndGraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.Moderate {
    class ConvertTreeToList {
        public static Tuple<BinaryTreeNode, BinaryTreeNode> Convert(BinaryTreeNode root) {
            if (root == null) {
                return null;
            }

            var left = Convert(root.Left);
            var right = Convert(root.Right);

            if (left != null) {
                Concat(left.Item2, root);
            }

            if (right != null) {
                Concat(root, right.Item1);
            }

            return Tuple.Create(
                left != null ? left.Item1 : root,
                right != null ? right.Item2 : root);
        }

        private static void Concat(BinaryTreeNode x, BinaryTreeNode y) {
            x.Right = y;
            y.Left = x;
        }
    }
}
