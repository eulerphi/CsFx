using System;
using System.Collections.Generic;
using System.Linq;

namespace codechef.hard {
    class orders {
        public static void Run(string[] args) {
            //var numProblems = int.Parse(Console.In.ReadLine());
            //for (var i = 0; i < numProblems; i++) {
            //    Console.In.ReadLine();
            //    var input = Console.In.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            //    Console.Out.WriteLine(OrderTree(input));
            //}

            var rand = new Random();
            var input = new List<int>();
            for (var i = 0; i < 10; i++) {
                input.Add(rand.Next(0, i));
            }

            var i1 = input.ToList();

            //input = new List<int>();
            //input.Add(0);
            //input.Add(0);
            //input.Add(1);
            //input.Add(2);
            //input.Add(2);
            var i2 = input.ToList();


            var o1 = OrderTree(input);
            Console.WriteLine(o1);
            Console.Read();
        }

        public static string OrderBrute(List<int> input) {
            var offsets = new List<int>();
            for (var i = input.Count - 1; i >= 0; i--) {
                var value = input[i];
                input[i] *= -1;
                for (var j = 0; j < offsets.Count; j++) {
                    if (offsets[j] > 0) {
                        input[i]++;
                        offsets[j]--;
                    }
                }

                if (value > 0) {
                    offsets.Add(value);
                }
            }

            for (var i = 0; i < input.Count; i++) {
                input[i] += i + 1;
            }

            return String.Join(" ", input);
        }

        public static string OrderTree(List<int> input) {
            TreeNode root = null;
            for (var i = 0; i < input.Count; i++) {
                var current = input[i];
                var node = new TreeNode { Index = i };

                if (root == null) {
                    root = node;
                } else {
                    root.Insert(node, i - current);
                }
            }

            var pos = 1;
            root.Traverse(input, ref pos);
            return String.Join(" ", input);
        }

        class TreeNode {
            public int Index { get; set; }
            public int LeftCount { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }

            public void Insert(TreeNode other, int newIndex) {
                var count = this.LeftCount + 1;
                if (count > newIndex) {
                    if (this.Left == null) {
                        this.Left = other;
                    } else {
                        this.Left.Insert(other, newIndex);
                    }
                    this.LeftCount++;
                } else {
                    if (this.Right == null) {
                        this.Right = other;
                    } else {
                        this.Right.Insert(other, newIndex - count);
                    }
                }
            }

            public void Traverse(List<int> output, ref int pos) {
                if (this.Left != null) {
                    this.Left.Traverse(output, ref pos);
                }

                output[this.Index] = pos++;

                if (this.Right != null) {
                    this.Right.Traverse(output, ref pos);
                }
            }
        }
    }
}
