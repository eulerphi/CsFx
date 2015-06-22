using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.dynamicprogramming {
    class CountSteps {
        public static int Count(int n, int k) {
            if (n == 0) {
                return 1;
            }

            if (n < 0) {
                return 0;
            }

            var count = 0;
            for (var i = 1; i <= k; i++) {
                count += Count(n - i, k);
            }

            return count;
        }

        public static int CountBuild(int n, int k) {
            var table = new int[n + 1];

            table[0] = 1;
            for (var i = 1; i <= n; i++) {
                for (var j = 1; j <= k; j++) {
                    if (i >= j) {
                        table[i] += table[i - j];
                    }
                }
            }

            return table[n];
        }
    }
}
