using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codechef.hard {
    class teamsel {
        public static void Run(string[] args) {
            //var numProblems = int.Parse(Console.ReadLine());
            //for (var i = 0; i < numProblems; i++) {
            //    Console.ReadLine();
            //    Console.ReadLine();
            //    var input = Console.ReadLine()
            //        .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            //        .Select(int.Parse)
            //        .OrderByDescending(x => x)
            //        .ToList();



            var input = new List<int> { 87, 100, 28, 67, 68, 41, 67, 1 }.OrderByDescending(x => x).ToList();
            var sum = input.Sum();
            var half = sum / 2;

            var table = TeamTable(input);
            var max = Find(table, 0, input.Count / 2, 0, half);
            max = input.Count % 2 == 1
                ? Math.Max(max, Find(table, 0, input.Count / 2 + 1, 0, half))
                : max;
            Console.WriteLine(max);

            //}
        }

        private static int Find(int[,] t, int lo, int hi, int acc, int max) {
            if (hi == 0) return 0;

            var n = t.GetLength(0);
            if (acc + t[n - hi, n - 1] > max) {
                return 0;
            }

            var sum = 0;
            for (var i = lo; i < n - hi; i++) {
                var temp = acc + t[i, i + hi - 1];
                if (temp <= max) {
                    return Math.Max(temp, sum);
                }

                if (acc + t[i, i] > max) {
                    continue;
                }

                var r = Find(t, i + 1, hi - 1, acc + t[i, i], max);
                sum = Math.Max(sum, r);
                if (sum == max) {
                    return max;
                }
            }

            return sum;
        }

        private static int[,] TeamTable(List<int> input) {
            var table = new int[input.Count, input.Count];

            for (var i = 0; i < input.Count; i++) {
                table[i, i] = input[i];
                for (var j = i + 1; j < input.Count; j++) {
                    table[i, j] = table[i, j - 1] + input[j];
                }
            }

            return table;
        }
    }
}
