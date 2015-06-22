using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.RecursionAndDynamicProgramming {
    class CountNumberOfWaysSumCents {
        public static int Count(int n) {
            if (n < 1) {
                throw new ArgumentException();
            }

            return Count(n, 25);
        }

        private static int Count(int n, int denom) {
            if (denom == 1) {
                return 1;
            }

            var nextDenom = GetNextDenom(denom);

            var ways = 0;
            for (var i = 0; i * denom <= n; i++) {
                ways += Count(n - i * denom, nextDenom);
            }

            return ways;
        }

        private static int GetNextDenom(int denom) {
            switch (denom) {
                case 25: return 10;
                case 10: return 5;
                case 5: return 1;
                default: throw new InvalidOperationException();
            }
        }
    }
}
