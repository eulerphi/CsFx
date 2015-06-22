using CsFx.CtCI.TreesAndGraphs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.SortingAndSearching {
    class GetRankFromStream {
        private Node root;

        public void Track(int value) {
            if (this.root == null) {
                this.root = new Node(value);
            } else {
                this.root.Insert(value);
            }
        }

        public int GetRank(int value) {
            return this.GetRank(value, this.root, 0);
        }

        private int GetRank(int value, Node node, int currentRank) {
            if (node == null) {
                return -1;
            }

            var selfOrRightRank = currentRank + node.LeftSubtreeCount + 1;
            if (node.Value == value) {
                return selfOrRightRank;
            }

            return node.Value >= value
                ? GetRank(value, node.Left, currentRank)
                : GetRank(value, node.Right, selfOrRightRank);
        }

        class Node {
            public int Value { get; private set; }

            public int LeftSubtreeCount { get; private set; }
            public int RightSubtreeCount { get; private set; }

            public Node Left { get; private set; }
            public Node Right { get; private set; }

            public Node(int value) {
                this.Value = value;
            }

            public void Insert(int value) {
                if (this.Value >= value) {
                    if (this.Left == null) {
                        this.Left = new Node(value);
                    } else {
                        this.Left.Insert(value);
                    }

                    this.LeftSubtreeCount++;
                } else {
                    if (this.Right == null) {
                        this.Right = new Node(value);
                    } else {
                        this.Right.Insert(value);
                    }

                    this.RightSubtreeCount++;
                }
            }
        }
    }
}
