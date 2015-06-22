using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.ArraysAndStrings {
    class Problem3 {
        public bool Solution1(string a, string b) {
            if (a.Length != b.Length) {
                return false;
            }

            var aSorted = a.OrderBy(c => c).ToArray();
            var bSorted = b.OrderBy(c => c).ToArray();

            for (var i = 0; i < a.Length; i++) {
                if (aSorted[i] != bSorted[i]) {
                    return false;
                }
            }

            return true;
        }

        public bool Solution2(string a, string b) {
            if (a.Length != b.Length) {
                return false;
            }

            var charCounts = new Dictionary<char, int>();
            foreach (var c in a) {
                if (!charCounts.ContainsKey(c)) {
                    charCounts[c] = 0;
                }


                charCounts[c]++;
            }

            foreach (var c in b) {
                if (!charCounts.ContainsKey(c)) {
                    return false;
                } else if (charCounts[c] == 0) {
                    return false;
                } else {
                    charCounts[c]--;
                }
            }

            return true;
        }
    }
}
