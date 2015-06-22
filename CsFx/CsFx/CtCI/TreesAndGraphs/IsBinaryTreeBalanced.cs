using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.TreesAndGraphs {
    class IsBinaryTreeBalanced {
        const int NotBalanced = Int32.MinValue;

        public static bool IsBalanced(BinaryTreeNode root) {
            if (root == null) {
                return true;
            }

            return CheckHeight(root) != NotBalanced;
        }

        private static int CheckHeight(BinaryTreeNode root) {
            if (root == null) return 0;

            var leftHeight = CheckHeight(root.Left);
            if (leftHeight == NotBalanced) {
                return leftHeight;
            }

            var rightHeight = CheckHeight(root.Right);
            if (rightHeight == NotBalanced) {
                return rightHeight;
            }

            var heightDiff = leftHeight - rightHeight;
            return Math.Abs(heightDiff) <= 1
                ? 1 + Math.Max(leftHeight, rightHeight)
                : NotBalanced;
        }
    }
}
