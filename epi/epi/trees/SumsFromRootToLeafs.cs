using epi.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.trees {
    class SumsFromRootToLeafs {
        public static IList<int> GetSums(BinaryTreeNode root) {
            var allSums = new List<int>();
            GetSums(root, 0, allSums);
            return allSums;
        }

        private static void GetSums(BinaryTreeNode root, int currentSum, IList<int> allSums) {
            if (root == null) {
                return;
            }

            var newSum = currentSum << 1;
            newSum += root.Value;

            var leaf = root.Left == null && root.Right == null;
            if (leaf) {
                allSums.Add(newSum);
            } else {
                GetSums(root.Left, newSum, allSums);
                GetSums(root.Right, newSum, allSums);
            }
        }
    }
}
