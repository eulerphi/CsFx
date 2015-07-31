using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.recursion {
    class SatExpression {
        public static void Run() {
            var values = "1232537859";
            var result = new List<string>();
            Console.WriteLine(Sat(values, 995, 0, 0, result));
        }

        private static bool Sat(string values, int k, int j, int runningMult, List<string> result) {
            if (j >= values.Length) {
                return k == 0 || k == runningMult;
            }

            for (var i = j; i < values.Length; i++) {
                var take = i - j + 1;
                var v = int.Parse(values.Substring(j, take));

                var plus = Sat(values, k - v - runningMult, i + 1, 0, result);
                if (plus) {
                    if (runningMult > 0) {
                        result.Add(runningMult.ToString());
                        result.Add("+");
                    }
                    result.Add(v.ToString());
                    result.Add("+");
                    return true;
                }

                var newRunningMult = runningMult == 0 ? v : runningMult * v;
                var mult = Sat(values, k, i + 1, newRunningMult, result);
                if (mult) {
                    return true;
                }
            }

            return false;
        }
    }
}
