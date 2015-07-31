using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.strings {
    class EliasGammaEncoding {
        public static void Run() {
            var encoded = EliasGammaEncoding.Encode(new int[] { 13, 12, 255 });
            var decoded = EliasGammaEncoding.Decode(encoded);
        }

        public static string Encode(int[] xs) {
            var result = new StringBuilder();
            foreach (var x in xs) {
                Encode(x, result);
            }

            return result.ToString();
        }

        private static void Encode(int x, StringBuilder result) {
            var numOfBits = CountNumberOfBits(x);

            var numOfLeadingZeros = numOfBits - 1;
            for (var i = 0; i < numOfLeadingZeros; i++) {
                result.Append("0");
            }

            for (var i = numOfBits - 1; i >= 0; i--) {
                var mask = 1 << i;
                var one = (x & mask) == mask;
                result.Append(one ? "1" : "0");
            }
        }

        private static int CountNumberOfBits(int x) {
            var count = 0;
            while (x > 0) {
                count++;
                x = x >> 1;
            }

            return count;
        }

        public static int[] Decode(string x) {
            var result = new List<int>();

            var prefixLength = 0;
            for (var i = 0; i < x.Length; i++) {
                if (x[i] == '1') {
                    result.Add(Decode(x, i, prefixLength + 1));
                    i += prefixLength;
                    prefixLength = 0;
                } else {
                    prefixLength++;
                }
            }

            return result.ToArray();
        }

        private static int Decode(string x, int start, int length) {
            var result = 0;
            for (var i = 0; i < length; i++) {
                if (x[start + i] == '1') {
                    result += 1 << length - i - 1;
                }
            }

            return result;
        }
    }
}
