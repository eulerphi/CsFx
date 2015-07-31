using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.hashes {
    class GetLongestDistinctSubarray {
        public static Tuple<int, int> Get(char[] text) {
            var result = Tuple.Create(-1, -1);
            var resultMax = 0;

            var lastSeen = new Dictionary<char, int>();
            var start = 0;

            for (var i = 0; i < text.Length; i++) {
                var c = text[i];
                if (lastSeen.ContainsKey(c)) {
                    start = lastSeen[c] + 1;
                }

                lastSeen[c] = i;

                var length = i - start;
                if (length > resultMax) {
                    result = Tuple.Create(start, i);
                    resultMax = length;
                }
            }

            return result;
        }
    }
}
