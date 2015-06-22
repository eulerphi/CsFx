using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.TreesAndGraphs {
    class IsSubtree {
        public static bool Check(BinaryTreeNode parent, BinaryTreeNode child) {
            if (child == null) {
                return true;
            }

            return TraverseAndMatch(parent, child);
        }

        private static bool TraverseAndMatch(BinaryTreeNode parent, BinaryTreeNode child) {
            if (parent == null) {
                return false;
            }

            var foundMatch = parent.Value == child.Value
                          && Match(parent, child);

            return foundMatch
                || TraverseAndMatch(parent.Left, child)
                || TraverseAndMatch(parent.Right, child);
        }

        private static bool Match(BinaryTreeNode parent, BinaryTreeNode child) {
            if (parent == null && child == null) {
                return true;
            }

            if (parent == null || child == null) {
                return false;
            }

            return Match(parent.Left, child.Left)
                && Match(parent.Right, child.Right);
        }
    }
}
