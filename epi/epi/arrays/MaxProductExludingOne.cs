using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.arrays {
    class MaxProductExludingOne {
        public static void Run() {
            var xs = new int[] { 3, 2, -1, 4, -1, 6, 0 };
            var result = Compute(xs);
        }

        private static int Compute(int[] xs) {
            Array.Sort(xs);
            var lastNegIdx = -1;
            var firstPosIdx = -1;
            for (var i = 0; i < xs.Length; i++) {
                if (xs[i] < 0 && (i + 1 == xs.Length || xs[i + 1] >= 0)) {
                    lastNegIdx = i;
                }

                if (xs[i] > 0) {
                    firstPosIdx = i;
                    break;
                }

            }

            var negCount = lastNegIdx + 1;
            var posCount = xs.Length - firstPosIdx;
            var zeroCount = xs.Length - negCount - posCount;

            if (zeroCount > 1) {
                return 0;
            } else if (negCount % 2 == 1) {
                return zeroCount == 0
                    ? Mult(xs, 0, lastNegIdx - 1) * Mult(xs, firstPosIdx, xs.Length - 1)
                    : 0;
            } else if (negCount >= 0) {
                return zeroCount == 0
                    ? Mult(xs, 0, lastNegIdx) * Mult(xs, firstPosIdx + 1, xs.Length - 1)
                    : Mult(xs, 0, lastNegIdx) * Mult(xs, firstPosIdx, xs.Length - 1);
            } else {
                return Mult(xs, 1, xs.Length - 1);
            }
        }

        private static int Mult(int[] xs, int lo, int hi) {
            var result = 1;
            for (var i = lo; i <= hi; i++) {
                result *= xs[i];
            }

            return result;
        }
    }
}
