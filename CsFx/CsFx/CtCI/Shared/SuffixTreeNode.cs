using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.Shared {
    class SuffixTreeNode {
        private readonly IDictionary<char, SuffixTreeNode> children;
        private readonly IList<int> indexes;

        private SuffixTreeNode() {
            this.children = new Dictionary<char, SuffixTreeNode>();
            this.indexes = new List<int>();
        }

        public static SuffixTreeNode Create(string s) {
            var root = new SuffixTreeNode();
            for (var i = 0; i < s.Length; i++) {
                var suffix = s.Substring(i);
                root.InsertString(suffix, i);
            }

            return root;
        }

        public IList<int> Search(string s) {
            if (String.IsNullOrEmpty(s)) {
                return this.indexes;
            } else {
                var first = s[0];
                if (children.ContainsKey(first)) {
                    var remainder = s.Substring(1);
                    return children[first].Search(remainder);
                }
            }

            return null;
        }

        private void InsertString(string s, int index) {
            indexes.Add(index);
            if (!String.IsNullOrEmpty(s)) {
                var value = s[0];

                SuffixTreeNode child = null;
                if (children.ContainsKey(value)) {
                    child = children[value];
                } else {
                    child = new SuffixTreeNode();
                    children[value] = child;
                }

                var remainder = s.Substring(1);
                child.InsertString(remainder, index);
            }
        }
    }
}
