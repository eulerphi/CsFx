using epi.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.trees {
    class AlmostBst {
        public static void Run() {
            var root = new BinaryTreeNode {
                Value = 17,
                Left = new BinaryTreeNode {
                    Value = 41,
                    Right = new BinaryTreeNode {
                        Value = 17
                    }
                },
                Right = new BinaryTreeNode {
                    Value = 23,
                    Left = new BinaryTreeNode {
                        Value = 21
                    },
                    Right = new BinaryTreeNode {
                        Value = 5,
                        Left = new BinaryTreeNode {
                            Value = 30
                        },
                        Right = new BinaryTreeNode {
                            Value = 100,
                            Left = new BinaryTreeNode {
                                Value = 10
                            }
                        }
                    }
                }
            };

            var result = CheckBook(root);
        }

        private static bool CheckBook(BinaryTreeNode root) {
            var inorder = Inorder(root);

            var firstSwap = true;
            for (var i = 0; i < inorder.Length - 1; i++) {
                var curr = inorder[i];
                var next = inorder[i + 1];
                if (curr <= next) {
                    continue;
                }

                if (!firstSwap) {
                    return false;
                }

                firstSwap = false;

                var j = i + 1;
                for (; j < inorder.Length; j++) {
                    if (inorder[j] <= next && curr >= inorder[j - 1] && (j + 1 == inorder.Length || curr <= inorder[j + 1])) {
                        break;
                    }
                }

                if (j < inorder.Length) {
                    Swap(inorder, i, j);
                } else {
                    return false;
                }

            }

            return true;
        }

        private static void Swap(int[] inorder, int i, int j) {
            var temp = inorder[i];
            inorder[i] = inorder[j];
            inorder[j] = temp;
        }

        private static int[] Inorder(BinaryTreeNode root) {
            var items = new List<int>();
            Inorder(root, items);
            return items.ToArray();
        }

        private static void Inorder(BinaryTreeNode root, List<int> items) {
            if (root == null) return;

            Inorder(root.Left, items);
            items.Add(root.Value);
            Inorder(root.Right, items);
        }

        private static bool CheckOriginal(BinaryTreeNode root) {
            var candidates = new List<Info>();
            var min = int.MinValue;
            var max = int.MaxValue;

            CheckOriginal(root, min, max, candidates);
            if (!candidates.Any()) return true;
            if (candidates.Count != 2) return false;

            var x = candidates[0];
            var y = candidates[1];

            var bstProp = x.CanChangeTo(y) && y.CanChangeTo(x);
            if (!bstProp) return false;

            return true;
        }

        private static void CheckOriginal(BinaryTreeNode root, int min, int max, List<Info> candidates) {
            if (root == null) return;

            var bstProp = root.Value > min && root.Value <= max;
            if (!bstProp) {
                candidates.Add(new Info { Node = root, Min = min, Max = max });

                if (root.Left != null) {
                    CheckOriginal(root.Left, min, max, candidates);
                }

                if (root.Right != null) {
                    CheckOriginal(root.Right, min, max, candidates);
                }
            } else {
                CheckOriginal(root.Left, min, root.Value, candidates);
                CheckOriginal(root.Right, root.Value, max, candidates);
            }
        }

        class Info {
            public BinaryTreeNode Node { get; set; }
            public int Max { get; set; }
            public int Min { get; set; }

            public bool CanChangeTo(Info other) {
                var newValue = other.Node.Value;
                return newValue > this.Min && newValue <= this.Max
                    && (this.Node.Left == null || this.Node.Left.Value <= newValue)
                    && (this.Node.Right == null || this.Node.Right.Value > newValue);
            }
        }
    }
}
