using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ada1 {
    class CountInversions {
        public static void Run() {
            var values = File
                .ReadAllLines(@"P1_IntegerArray.txt")
                .Select(Int32.Parse)
                .ToArray();
            var count = CountInversions.Count(values);
            Console.WriteLine(count);
            Console.Read();
        }

        public static long CountSlow(int[] values) {
            long count = 0;
            for (var i = 0; i < values.Length - 1; i++) {
                for (var j = i + 1; j < values.Length; j++) {
                    count += values[i] > values[j] ? 1 : 0;
                }
            }

            return count;
        }

        public static long Count(int[] values) {
            return Count(values, 0, values.Length - 1);
        }

        private static long Count(int[] values, int lo, int hi) {
            if (lo >= hi) return 0;

            var mid = lo + (hi - lo) / 2;
            var left = Count(values, lo, mid);
            var right = Count(values, mid + 1, hi);
            var merge = Merge(values, lo, mid, hi);
            return left + right + merge;
        }

        private static long Merge(int[] values, int lo, int mid, int hi) {
            var l = lo;
            var r = mid + 1;

            var inversionCount = 0;

            var temp = values.ToArray();
            for (var i = lo; i <= hi; i++) {
                if (l > mid) {
                    values[i] = temp[r++];
                } else if (r > hi) {
                    values[i] = temp[l++];
                } else if (temp[r] < temp[l]) {
                    values[i] = temp[r++];
                    inversionCount += mid - l + 1;
                } else {
                    values[i] = temp[l++];
                }
            }

            return inversionCount;
        }
    }
}
