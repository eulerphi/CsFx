using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.Core {
    public class QuickSort {
        public static void Sort(int[] a) {
            if (a == null) {
                throw new ArgumentNullException("a");
            }

            Sort(a, 0, a.Length - 1);
        }

        private static void Sort(int[] a, int start, int end) {
            if (start >= end) {
                return;
            }

            var midRange = Partition(a, start, end);
            Sort(a, start, midRange.Item1 - 1);
            Sort(a, midRange.Item2 + 1, end);
        }

        private static Tuple<int, int> Partition(int[] a, int start, int end) {
            var partitionValue = a[start];
            var lo = start;
            var hi = end;
            var i = start + 1;

            while (i <= hi) {
                if (partitionValue == a[i]) {
                    i++;
                } else if (a[i] > partitionValue) {
                    Exchange(a, i, hi);
                    hi--;
                } else { // partitionValue > a[i]
                    Exchange(a, i, lo);
                    lo++;
                    i++;
                }
            }

            return Tuple.Create(lo, hi);
        }

        private static void Exchange(int[] a, int i, int j) {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}
