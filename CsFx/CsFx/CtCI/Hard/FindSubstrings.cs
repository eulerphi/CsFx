using CsFx.CtCI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.Hard {
    class FindSubstrings {
        public static IEnumerable<string> Find(string s, string[] ts) {
            var root = SuffixTreeNode.Create(s);
            foreach (var t in ts) {
                var indexes = root.Search(t);
                if (indexes != null) {
                    yield return t;
                }
            }
        }
    }
}
