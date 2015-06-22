using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.dynamicprogramming {
    class CountScoreCombinations {
        public static int Count(int total, int[] values) {
            var cache = new Dictionary<Tuple<int, int>, int>();
            return Count(total, values, 0, cache);
        }

        private static int Count(int total, int[] values, int valueIndex, Dictionary<Tuple<int, int>, int> cache) {
            if (total < 0) {
                return 0;
            }

            if (total == 0) {
                return 1;
            }

            if (valueIndex >= values.Length) {
                return 0;
            }

            var key = Tuple.Create(total, valueIndex);
            if (cache.ContainsKey(key)) {
                return cache[key];
            }

            var max = total / values[valueIndex];
            var ways = 0;
            for (var i = 0; i <= max; i++) {
                var take = values[valueIndex] * i;
                ways += Count(total - take, values, valueIndex + 1, cache);
            }

            cache.Add(key, ways);

            return ways;
        }


        public static int CountBook(int total, int[] values) {
            var combinations = Enumerable.Repeat(0, total + 1).ToList();
            combinations[0] = 1;
            foreach (var value in values) {
                for (var i = value; i <= total; i++) {
                    combinations[i] += combinations[i - value];
                }
            }

            return combinations[total];
        }

        public static int CountPermutations(int total, int[] values) {
            var permutations = Enumerable.Repeat(0, total + 1).ToList();
            permutations[0] = 1;

            for (var i = 1; i <= total; i++) {
                foreach (var value in values) {
                    if (i >= value) {
                        permutations[i] += permutations[i - value];
                    }
                }
            }

            return permutations[total];
        }

        public static IList<IList<int>> CountPermutationsWithLengths(int total, int[] values) {
            var permutations = new List<IList<int>>();
            for (var i = 0; i <= total; i++) {
                permutations.Add(new List<int>());
            }

            permutations[0].Add(0);

            for (var i = 1; i <= total; i++) {
                foreach (var value in values) {
                    if (i >= value) {
                        var from = permutations[i - value];
                        foreach (var p in from) {
                            permutations[i].Add(p + 1);
                        }
                    }
                }
            }

            return permutations;
        }


        public static IList<IList<int>> CountPermutationsWithValues(int total, int[] values) {
            var permutations = new List<IList<int>>();
            for (var i = 0; i <= total; i++) {
                permutations.Add(new List<int>());
            }

            permutations[0].Add(0);

            for (var i = 1; i <= total; i++) {
                foreach (var value in values) {
                    if (i >= value) {
                        var from = permutations[i - value];
                        foreach (var p in from) {
                            permutations[i].Add(p + 1);
                        }
                    }
                }
            }

            return permutations;
        }

        public static int CountVariant1(int total1, int total2, int[] values) {
            var table = CountPermutationsWithValues(Math.Max(total1, total2), values);
            var perms1 = table[total1];
            var perms2 = table[total2];

            var count = 0;
            foreach (var p1 in perms1) {
                foreach (var p2 in perms2) {
                    count += Factorial(p1 + p2) / Factorial(p1);
                }
            }

            return count;
        }

        public static int Factorial(int k) {
            int value = 1;
            for (var i = 2; i <= k; i++) {
                value *= i;
            }

            return value;
        }
    }
}
