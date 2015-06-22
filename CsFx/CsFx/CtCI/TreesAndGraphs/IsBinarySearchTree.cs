using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.TreesAndGraphs {
    class IsBinarySearchTree {
        public static bool IsBST(BinaryTreeNode root) {
            if (root == null) {
                throw new ArgumentNullException("root");
            }

            return IsBST(root, Int32.MinValue, Int32.MaxValue);
        }

        private static bool IsBST(BinaryTreeNode root, int min, int max) {
            if (root == null) {
                return true;
            }

            return root.Value > min
                && root.Value <= max
                && IsBST(root.Left, min, root.Value)
                && IsBST(root.Right, root.Value, max);
        }
    }
}
