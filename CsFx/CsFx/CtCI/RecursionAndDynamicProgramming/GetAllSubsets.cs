using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.RecursionAndDynamicProgramming {
    class GetAllSubsets {
        public static IEnumerable<IList<int>> ToPowerSet(IList<int> set) {
            var numberOfSubsets = (int)Math.Pow(2, set.Count);
            for (var i = 0; i < numberOfSubsets; i++) {
                yield return ToPowerSet(set, i);
            }
        }

        private static IList<int> ToPowerSet(IList<int> set, int flags) {
            var result = new List<int>();

            var index = 0;
            while (flags > 0) {
                if ((flags & 1) == 1) {
                    result.Add(set[index]);
                }

                flags >>= 1;
                index++;
            }

            return result;
        }
    }
}
