using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.Hard {
    class FindSmallestSubset {
        public static int[] Find(int[] input, int m) {
            var maxHeap = new List<int>();
            foreach (var value in input) {
                maxHeap.Add(value);
                if (maxHeap.Count > m) {
                    Debug.Assert(maxHeap.Count == m + 1);

                    var max = maxHeap.Max();
                    maxHeap.Remove(max);
                }
            }

            return maxHeap.ToArray();
        }
    }
}
