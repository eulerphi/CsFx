using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.Hard {
    class CountTwosBetweenZeroAndN {
        public static int Count(int n) {
            var count = 0;
            var length = n.ToString().Length;
            for (var i = 0; i < length; i++) {
                count += Count(n, i);
            }

            return count;
        }

        private static int Count(int n, int digit) {
            var powerOf10 = (int)Math.Pow(10, digit);
            var nextPowerOf10 = 10 * powerOf10;
            var right = n % powerOf10;

            var roundDown = n - n % nextPowerOf10;
            var roundUp = roundDown + nextPowerOf10;

            var value = (n / powerOf10) % 10;
            if (value < 2) {
                return roundDown / 10;
            } else if (value > 2) {
                return roundUp / 10;
            } else {
                return roundDown / 10 + right + 1;
            }
        }
    }
}
