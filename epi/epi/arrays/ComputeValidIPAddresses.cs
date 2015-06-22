using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.arrays {
    class ComputeValidIPAddresses {
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
