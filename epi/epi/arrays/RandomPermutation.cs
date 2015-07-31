using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.arrays {
    class RandomPermutation {
        public static void Run() {
            var a = Enumerable.Range(0, 7).ToArray();
            var result = Permutate(a, a.Length);
        }

        private static int[] Permutate(int[] xs, int k) {
            var result = new int[k];
            var map = xs.ToDictionary(x => x);
            var rand = new Random();
            for (var i = 0; i < k; i++) {
                var j = rand.Next(xs.Length - i);
                result[i] = map[i + j];
                map[i + j] = map[i];
            }

            return result;
        }
    }
}
