using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.arrays {
    class PermuteWithTable {
        public static void Run() {
            for (var t = 0; t < 1000; t++) {
                var xs = Enumerable.Range(0, 5).ToArray();
                var ps = Enumerable.Range(0, 5).ToArray();

                var rand = new Random();
                for (var i = 0; i < ps.Length; i++) {
                    var j = rand.Next(ps.Length - i);
                    var temp = ps[i];
                    ps[i] = ps[j];
                    ps[j] = temp;
                }

                var xsp = xs.ToArray();
                var psp = ps.ToArray();
                Permute(xs, ps);
                PermuteBook(xsp, psp);

                for (var m = 0; m < xs.Length; m++) {
                    if (xs[m] != xsp[m]) {
                        throw new Exception();
                    }
                }
            }
        }

        public static void Permute(int[] xs, int[] ps) {
            for (var i = 0; i < xs.Length; ) {
                if (ps[i] == i) {
                    i++;
                    continue;
                }

                var from = i;
                var to = ps[i];

                var temp = xs[from];
                xs[from] = xs[to];
                xs[to] = temp;

                temp = ps[from];
                ps[from] = ps[to];
                ps[to] = temp;
            }
        }

        public static void PermuteBook(int[] a, int[] p) {
            for (var i = 0; i < a.Length; i++) {
                if (p[i] >= 0) {
                    var j = i;
                    var temp = a[i];
                    do {
                        var next_j = p[j];
                        var next_temp = a[next_j];
                        a[next_j] = temp;
                        p[j] -= p.Length;
                        j = next_j;
                        temp = next_temp;
                    } while (j != i);
                }
            }

            for (var i = 0; i < p.Length; i++) {
                p[i] += p.Length;
            }
        }
    }
}
