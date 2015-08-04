using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codechef.medium {
    class coins {
        public static void Run(string[] args) {
            var cache = new Dictionary<long, long>();

            long value = 0;
            while (true) {
                var input = Console.ReadLine();
                if (long.TryParse(input, out value)) {
                    Console.WriteLine(Max(value, cache));
                } else {
                    break;
                }
            }
        }

        private static long Max(long input, Dictionary<long, long> cache) {
            if (input < 12) {
                return input;
            }

            if (cache.ContainsKey(input)) {
                return cache[input];
            }

            var result = Max(input / 2, cache) + Max(input / 3, cache) + Max(input / 4, cache);
            cache[input] = result;

            return result;
        }
    }
}
