using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ada1 {
    class QuickSort {
        public static void Run() {
            var values = File
                .ReadAllLines(@"P2_QuickSort.txt")
                .Select(Int32.Parse)
                .ToArray();
            var count = Sort(values);
            Console.WriteLine(count);
            Console.Read();
        }

        public static long Sort(int[] a) {
            return Sort(a, 0, a.Length - 1);
        }

        private static long Sort(int[] a, int lo, int hi) {
            if (lo >= hi) return 0;

            var mid = lo + (hi - lo) / 2;
            var pIndex = new Tuple<int, int>[] {
                Tuple.Create(lo, a[lo]),
                Tuple.Create(mid, a[mid]),
                Tuple.Create(hi, a[hi])
            }.OrderBy(t => t.Item2).ElementAt(1).Item1;

            Swap(a, lo, pIndex);

            //Swap(a, lo, hi);

            var p = a[lo];
            var lte = lo + 1;
            for (var i = lo + 1; i <= hi; i++) {
                if (a[i] < p) Swap(a, lte++, i);
            }

            Swap(a, lo, lte - 1);

            return (hi - lo)
                + Sort(a, lo, lte - 2)
                + Sort(a, lte, hi);


            //var p = a[lo];
            //var lt = lo;
            //var gt = hi;

            //var i = lo + 1;
            //while (i <= gt) {
            //    if (a[i] == p) i++;
            //    else if (a[i] < p) Swap(a, i++, lt++);
            //    else Swap(a, i, gt--);
            //}

            //return (hi - lo)
            //    + Sort(a, lo, lt - 1)
            //    + Sort(a, gt + 1, hi);
        }

        private static void Swap(int[] a, int i, int j) {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}
