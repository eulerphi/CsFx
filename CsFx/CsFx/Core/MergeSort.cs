using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.Core {
    public class MergeSort {
        public static void Sort(int[] a) {
            if (a == null) {
                throw new ArgumentNullException("a");
            }

            var temp = new int[a.Length];
            Sort(a, 0, a.Length - 1, temp);
        }

        private static void Sort(int[] a, int lo, int hi, int[] temp) {
            if (lo >= hi) {
                return;
            }

            var mid = lo + (hi - lo) / 2;
            Sort(a, lo, mid, temp);
            Sort(a, mid + 1, hi, temp);
            Merge(a, lo, mid, hi, temp);
        }

        private static void Merge(int[] a, int lo, int mid, int hi, int[] temp) {
            var i = lo;
            var j = mid + 1;

            CopyArray(a, temp);

            for (var c = lo; c <= hi; c++) {
                if (i > mid) {
                    a[c] = temp[j++];
                } else if (j > hi) {
                    a[c] = temp[i++];
                } else if (temp[j] < temp[i]) {
                    a[c] = temp[j++];
                } else {
                    a[c] = temp[i++];
                }
            }
        }

        private static void CopyArray(int[] source, int[] target) {
            for (var i = 0; i < source.Length; i++) {
                target[i] = source[i];
            }
        }
    }
}
