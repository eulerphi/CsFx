using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.Core {
    public class CountInversions {
        public static int Count(int[] a) {
            if (a == null) {
                throw new ArgumentNullException("a");
            }

            var temp = new int[a.Length];
            return SortAndCount(a, 0, a.Length - 1, temp);
        }

        private static int SortAndCount(int[] a, int lo, int hi, int[] temp) {
            if (lo >= hi) {
                return 0;
            }

            var mid = lo + (hi - lo) / 2;
            return SortAndCount(a, lo, mid, temp)
                 + SortAndCount(a, mid + 1, hi, temp)
                 + Merge(a, lo, mid, hi, temp);
        }

        private static int Merge(int[] a, int lo, int mid, int hi, int[] temp) {
            var i = lo;
            var j = mid + 1;

            for (var k = lo; k <= hi; k++) {
                temp[k] = a[k];
            }

            var inversions = 0;
            for (var k = lo; k <= hi; k++) {
                if (i > mid) {
                    a[k] = temp[j++];
                } else if (j > hi) {
                    a[k] = temp[i++];
                } else if (temp[j] < temp[i]) {
                    a[k] = temp[j++];
                    inversions += (mid - i) + 1;
                } else {
                    a[k] = temp[i++];
                }
            }

            return inversions;
        }
    }
}
