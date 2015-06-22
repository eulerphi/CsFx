using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.TreesAndGraphs {
    class BinaryTreeNodeWithParent {
        private BinaryTreeNodeWithParent left;
        public BinaryTreeNodeWithParent Left {
            get { return this.left; }
            set {
                this.left = value;
                if (this.left != null) {
                    this.left.Parent = this;
                }
            }
        }

        private BinaryTreeNodeWithParent right;
        public BinaryTreeNodeWithParent Right {
            get { return this.right; }
            set {
                this.right = value;
                if (this.right != null) {
                    this.right.Parent = this;
                }
            }
        }

        public BinaryTreeNodeWithParent Parent { get; private set; }
        public int Value { get; set; }
    }
}
