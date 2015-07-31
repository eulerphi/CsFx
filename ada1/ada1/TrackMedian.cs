using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ada1 {
    class TrackMedian {
        public static void Run() {
            var values = File.ReadLines("P6_Median.txt").Select(int.Parse).ToList();

            var sum = 0;

            var left = new MinHeap<int, int>(x => -x);
            var right = new MinHeap<int, int>(x => x);
            foreach (var v in values) {
                var leftMax = left.Any() ? left.Peek() : int.MinValue;

                if (v > leftMax) {
                    right.Insert(v);
                } else {
                    left.Insert(v);
                }

                if (right.Count - left.Count > 1) {
                    left.Insert(right.Extract());

                } else if (left.Count - right.Count > 1) {
                    right.Insert(left.Extract());
                }

                var count = left.Count + right.Count;
                var even = count % 2 == 0;
                var medianIndex = even ? (count - 1) / 2 : count / 2;

                var median = medianIndex == left.Count - 1
                    ? left.Peek()
                    : right.Peek();

                //Console.Write(v);
                //Console.Write(" | ");
                //Console.Write(sum);
                //Console.Write(" + ");
                //Console.Write(median);
                //Console.Write(" = ");
                sum += median;
                //Console.WriteLine(sum);
            }

            Console.WriteLine(sum % 10000);
        }
    }
}
