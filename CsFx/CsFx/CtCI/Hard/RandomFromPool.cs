using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.Hard {
    class RandomFromPool {
        public static int[] PickRandomly(int[] a, int m, int seed) {
            var subset = new int[m];
            var clone = (int[])a.Clone();

            var rand = new Random(seed);
            for (var i = 0; i < m; i++) {
                var index = rand.Next(i, a.Length);
                subset[i] = clone[index];
                clone[index] = clone[i];
            }

            return subset;
        }
    }
}
