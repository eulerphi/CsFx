using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.common {
    class BinaryTreeNode {
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }
        public int Value { get; set; }
    }

    class BinaryTreeNode<T> {
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
        public T Value { get; set; }
    }
}
