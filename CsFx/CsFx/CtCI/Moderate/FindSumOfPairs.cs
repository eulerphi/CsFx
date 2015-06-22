using CsFx.CtCI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.Moderate {
    class FindSumOfPairs {
        public static IEnumerable<Pair> Find(int[] a, int sum) {
            if (a == null) {
                throw new ArgumentNullException();
            }

            var set = new HashSet<int>();
            foreach (var value in a) {
                set.Add(value);
            }

            foreach (var value in a) {
                var complement = sum - value;
                if (set.Contains(complement)) {
                    set.Remove(value);

                    yield return new Pair(value, complement);
                }
            }
        }
    }
}
