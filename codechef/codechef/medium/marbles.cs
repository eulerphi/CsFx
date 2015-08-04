using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codechef.medium {
    class marbles {
        public static void Run(string[] args) {
            var cache = new Dictionary<Tuple<int, int>, long>();

            var numCases = int.Parse(Console.ReadLine());
            for (var i = 0; i < numCases; i++) {
                var input = Console.ReadLine().Split(' ');
                var marbles = int.Parse(input[0]);
                var colors = int.Parse(input[1]);
                //Console.WriteLine(Run(marbles, colors, cache));
                //Console.WriteLine(Combination(marbles - 1, marbles - colors));
                Console.WriteLine(NChooseK(marbles - 1, colors - 1));
            }
        }

        public static long Combination(int first, int second) {
            long result = 1;
            if (first / 2 < second)
                second = first - second;
            for (int i = 1; i <= second; i++) {
                result = result * first--;
                result = result / i;
            }
            return result;
        }
        public static long NChooseK(int n, int k) {
            long result = 1;
            for (uint i = 1; i <= k; i++) {
                result *= (n - (k - i));
                result /= i;
            }
            return result;
        }

        private static long Run(int marbles, int colors, Dictionary<Tuple<int, int>, long> cache) {
            if (marbles < 1 || colors < 1) {
                return 0;
            }

            if (marbles > 0 && colors == 1) {
                return 1;
            }

            if (marbles == colors) {
                return 1;
            }

            var key = Tuple.Create(marbles, colors);
            if (cache.ContainsKey(key)) {
                return cache[key];
            }

            long result = 0;
            for (var i = 1; i <= marbles - colors + 1; i++) {
                result += Run(marbles - i, colors - 1, cache);
            }

            cache[key] = result;
            return result;
        }
    }
}
