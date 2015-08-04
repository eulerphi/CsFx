using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codechef.medium {
    class prime1 {
        public static void Run(string[] args) {
            var bound = 1000000000;
            var t = new BitArray(bound);
            for (var i = 2; i <= bound; i++) {
                if (t[i - 1]) continue;

                for (var x = 2; x < bound / i; x++) {
                    t[(i - 1) * x] = true;
                }
            }

            var numCases = int.Parse(Console.ReadLine());
            for (var i = 0; i < numCases; i++) {
                var input = Console
                    .ReadLine()
                    .Split(new [] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                for (var j = input[1]; j <= input[1]; j++) {
                    if (!t[j]) {
                        Console.WriteLine(j);
                    }
                }
            }
        }
    }
}
