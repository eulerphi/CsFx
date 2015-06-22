using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.ArraysAndStrings {
    class Problem1 {
        public bool Solution1(string value) {
            for (var i = 0; i < value.Length; i++) {
                for (var j = i + 1; j < value.Length; j++) {
                    if (value[i] == value[j]) {
                        return false;
                    }
                }
            }

            return true;
        }


        public bool Solution2(string value) {
            if (value.Length > 256) {
                return false;
            }

            var asciiChars = new bool[256];
            foreach (var c in value) {
                if (asciiChars[c]) {
                    return false;
                }

                asciiChars[c] = true;
            }

            return true;
        }

        public bool Solution3(string value) {
            var seen = new HashSet<char>();
            foreach (var c in value) {
                if (seen.Contains(c)) {
                    return false;
                }

                seen.Add(c);
            }

            return true;
        }
    }
}
