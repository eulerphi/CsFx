using epi.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.trees {
    class ReconstructFromTraversals {
        public static BinaryTreeNode<char> Reconstruct(char[] inorder, char[] preorder) {
            var lookup = new Dictionary<char, int>();
            for (var i = 0; i < preorder.Length; i++) {
                lookup.Add(inorder[i], i);
            }
            return Reconstruct(0, 0, inorder.Length - 1, inorder, preorder, lookup).Node;
        }

        private static Result Reconstruct(int i, int lo, int hi, char[] inorder, char[] preorder, Dictionary<char, int> lookup) {
            if (lo > hi) {
                return new Result();
            }

            var value = preorder[i];
            var mid = lookup[value];
            var leftResult = Reconstruct(i + 1, lo, mid - 1, inorder, preorder, lookup);
            var rightResult = Reconstruct(i + leftResult.Count + 1, mid + 1, hi, inorder, preorder, lookup);

            return new Result {
                Node = new BinaryTreeNode<char> {
                    Value = value,
                    Left = leftResult.Node,
                    Right = rightResult.Node
                },
                Count = leftResult.Count + rightResult.Count + 1
            };
        }

        class Result {
            public BinaryTreeNode<char> Node { get; set; }
            public int Count { get; set; }
        }
    }
}
