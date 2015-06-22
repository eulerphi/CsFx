using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.TreesAndGraphs {
    class FindCommonAcestor {
        public static BinaryTreeNode Find(
            BinaryTreeNode root,
            BinaryTreeNode x,
            BinaryTreeNode y) {

            if (root == null) {
                throw new ArgumentNullException("root");
            } else if (x == null) {
                throw new ArgumentNullException("x");
            } else if (y == null) {
                throw new ArgumentNullException("y");
            }

            if (root == x || root == y) {
                return root;
            }

            var xOnLeft = IsDescendent(root.Left, x);
            var yOnLeft = IsDescendent(root.Left, y);

            var onDifferentSides = xOnLeft != yOnLeft;
            if (onDifferentSides) {
                return root;
            }

            return xOnLeft
                ? Find(root.Left, x, y)
                : Find(root.Right, x, y);
        }

        private static bool IsDescendent(BinaryTreeNode root, BinaryTreeNode node) {
            return root != null
                && (root == node ||
                    IsDescendent(root.Left, node) ||
                    IsDescendent(root.Right, node));

        }

        public static BinaryTreeNode Find2(
            BinaryTreeNode root,
            BinaryTreeNode x,
            BinaryTreeNode y) {

            if (root == null) {
                throw new ArgumentNullException("root");
            } else if (x == null) {
                throw new ArgumentNullException("x");
            } else if (y == null) {
                throw new ArgumentNullException("y");
            }

            var result = Find2Internal(root, x, y);
            return result.IsAncestor
                ? result.Node
                : null;
        }

        private static Find2Result Find2Internal(
            BinaryTreeNode root,
            BinaryTreeNode x,
            BinaryTreeNode y) {

            if (root == null) {
                return new Find2Result { IsAncestor = false };
            }

            if (root == x && root == y) {
                return new Find2Result {
                    Node = root,
                    IsAncestor = true
                };
            }

            var leftResult = Find2Internal(root.Left, x, y);
            if (leftResult.IsAncestor) {
                return leftResult;
            }

            var rightResult = Find2Internal(root.Right, x, y);
            if (rightResult.IsAncestor) {
                return rightResult;
            }

            var foundX = leftResult.Node == x
                      || rightResult.Node == x;
            var foundY = leftResult.Node == y
                      || rightResult.Node == y;

            if (foundX && foundY) {
                return new Find2Result {
                    IsAncestor = true,
                    Node = root
                };
            } else if (root == x || root == y) {
                return new Find2Result {
                    IsAncestor = foundX || foundY,
                    Node = root
                };
            } else {
                return new Find2Result {
                    IsAncestor = false,
                    Node = leftResult.Node != null ? leftResult.Node : rightResult.Node
                };
            }
        }

        class Find2Result {
            public BinaryTreeNode Node { get; set; }
            public bool IsAncestor { get; set; }
        }
    }
}
