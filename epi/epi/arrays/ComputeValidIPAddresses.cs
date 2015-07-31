using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.arrays {
    class ComputeValidIPAddresses {
        public static void Run() {
            var input = "25511";
            var builder = new StringBuilder();
            var result = new List<String>();
            Compute2(input, 3, builder, result);
        }

        private static void Compute2(string s, int count, StringBuilder builder, IList<string> result) {
            var last = count == 0;
            var length = builder.Length;

            foreach (var p in GetAllBytes(s)) {
                if (last && p.Item2.Any()) continue;

                builder.Append(p.Item1);
                if (last) {
                    result.Add(builder.ToString());
                } else {
                    builder.Append('.');
                    Compute2(p.Item2, count - 1, builder, result);
                }

                builder.Length = length;
            }
        }

        private static IEnumerable<Tuple<byte, string>> GetAllBytes(string s) {
            if (string.IsNullOrEmpty(s)) yield break;
            if (s.First() == '0') yield break;

            for (var i = 1; i <= 3 && i <= s.Length; i++) {
                byte result;
                if (byte.TryParse(s.Substring(0, i), out result)) {
                    yield return Tuple.Create(result, s.Substring(i));
                }
            }
        }

        public static IList<string> Compute(string value) {
            var result = new List<string>();
            var parts = new string[4];

            for (var l1 = 1; l1 < 4 && l1 < value.Length; l1++) {
                for (var l2 = 1; l2 < 4 && l1 + l2 < value.Length; l2++) {
                    for (var l3 = 1; l3 < 4 && l1 + l2 + l3 < value.Length; l3++) {
                        parts[0] = value.Substring(0, l1);
                        parts[1] = value.Substring(l1, l2);
                        parts[2] = value.Substring(l1 + l2, l3);
                        parts[3] = value.Substring(l1 + l2 + l3);

                        if (!parts.All(Validate)) {
                            continue;
                        }

                        result.Add(String.Join(".", parts));
                    }
                }
            }

            return result;
        }

        private static bool Validate(string part) {
            if (part.Length < 1 || part.Length > 3) {
                return false;
            }

            if (part.Length > 1 && part[0] == '0') {
                return false;
            }

            int value;
            if (!Int32.TryParse(part, out value)) {
                return false;
            }

            return value >= 0 && value < 256;
        }
    }
}
