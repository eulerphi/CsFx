using epi.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.arrays {
    class NextPermutation {
        public static void Next(int[] xs) {
            var to = xs.Length - 1;
            for (var i = xs.Length - 2; i >= 0; i--) {
                if (xs[i] < xs[i + 1]) {
                    to = i;
                    break;
                }
            }

            if (to == xs.Length - 1) {
                return;
            }

            var from = to;
            for (var i = xs.Length - 1; i > to; i--) {
                if (xs[i] > xs[to]) {
                    from = i;
                    break;
                }
            }

            Swap(xs, from, to);

            to = to + 1;
            from = xs.Length - 1;
            while (to < from) {
                Swap(xs, to++, from--);
            }
        }

        private static void Swap(int[] xs, int i, int j) {
            var temp = xs[i];
            xs[i] = xs[j];
            xs[j] = temp;
        }
    }
}
