using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.hashes {
    class GetLongestContainedRange {
        public static Tuple<int, int> Get(int[] input) {
            var result = Tuple.Create(-1, -1);
            var resultLength = 0;

            var set = new HashSet<int>();
            foreach (var c in input) {
                set.Add(c);
            }

            foreach (var c in input) {
                if (!set.Contains(c)) {
                    continue;
                }

                set.Remove(c);

                var lo = c - 1;
                while (set.Contains(lo)) {
                    set.Remove(lo);
                    lo--;
                }
                lo++;

                var hi = c + 1;
                while (set.Contains(hi)) {
                    set.Remove(hi);
                    hi++;
                }
                hi--;

                var length = hi - lo + 1;
                if (length > resultLength) {
                    result = Tuple.Create(lo, hi);
                    resultLength = length;
                }
            }

            return result;
        }
    }
}
