using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.TreesAndGraphs {
    class FindSumInBinaryTree {
        public static int[][] FindSum(BinaryTreeNode root, int sum) {
            if (root == null) {
                throw new ArgumentNullException("root");
            }

            var path = new List<int>();
            var sumPaths = new List<int[]>();

            FindPaths(root, sum, path, sumPaths);

            return sumPaths.ToArray();
        }

        private static void FindPaths(
            BinaryTreeNode root,
            int sumToFind,
            List<int> path,
            List<int[]> sumPaths) {

            if (root == null) {
                return;
            }

            path.Add(root.Value);

            var sum = 0;
            var level = path.Count - 1;
            for (var i = level; i >= 0; i--) {
                sum += path[i];
                if (sum == sumToFind) {
                    sumPaths.Add(path.Skip(i).ToArray());
                }
            }

            FindPaths(root.Left, sumToFind, path, sumPaths);
            FindPaths(root.Right, sumToFind, path, sumPaths);

            path.RemoveAt(path.Count - 1);
        }
    }
}
