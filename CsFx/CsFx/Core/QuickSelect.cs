using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.Core {
    public class QuickSelect {
        public static int Select(int[] a, int rank) {
            if (a == null) throw new ArgumentNullException("a");
            if (rank < 0 || rank > a.Length) throw new ArgumentException();

            return Select(a, 0, a.Length - 1, rank - 1);
        }

        private static int Select(int[] a, int lo, int hi, int targetIndex) {
            var mid = lo + (hi - lo) / 2;

            var midRange = Partition(a, lo, mid, hi);
            if (targetIndex >= midRange.Item1 && targetIndex <= midRange.Item2) {
                return a[targetIndex];
            } else if (targetIndex < midRange.Item1) {
                return Select(a, lo, midRange.Item1 - 1, targetIndex);
            } else {
                return Select(a, midRange.Item2 + 1, hi, targetIndex);
            }
        }

        private static Tuple<int, int> Partition(int[] a, int lo, int mid, int hi) {
            var v = a[lo];

            var lt = lo;
            var gt = hi;
            var i = lo;

            while (i <= gt) {
                if (a[i] > v) {
                    Exchange(a, i, gt--);
                } else if (a[i] < v) {
                    Exchange(a, i++, lt++);
                } else {
                    i++;
                }
            }

            return Tuple.Create(lt, gt);
        }

        private static void Exchange(int[] a, int i, int j) {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}
