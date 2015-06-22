using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.RecursionAndDynamicProgramming {
    class CountNumberOfWaysUpStairs {
        public static int Count(int numberOfStairs) {
            if (numberOfStairs < 0) {
                return 0;
            } else if (numberOfStairs == 0) {
                return 1;
            } else {
                return Count(numberOfStairs - 1)
                     + Count(numberOfStairs - 2)
                     + Count(numberOfStairs - 3);
            }
        }


        public static int CountMemo(int numberOfStairs) {
            var countCache = new Dictionary<int, int>();
            return CountMemo(numberOfStairs, countCache);
        }

        private static int CountMemo(
            int numberOfStairs,
            Dictionary<int, int> countCache) {


            if (numberOfStairs < 0) {
                return 0;
            } else if (numberOfStairs == 0) {
                return 1;
            } else if (countCache.ContainsKey(numberOfStairs)) {
                return countCache[numberOfStairs];
            } else {
                var count = CountMemo(numberOfStairs - 1, countCache)
                          + CountMemo(numberOfStairs - 2, countCache)
                          + CountMemo(numberOfStairs - 3, countCache);

                countCache[numberOfStairs] = count;
                return count;
            }

        }
    }
}
