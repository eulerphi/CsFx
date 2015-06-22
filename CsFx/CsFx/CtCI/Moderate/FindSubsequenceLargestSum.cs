using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.Moderate {
    class FindSubsequenceLargestSum {
        public static int Find(int[] a) {
            if (a == null) {
                throw new ArgumentNullException();
            }

            var maxSum = 0;
            
            var currentSum = 0;
            for (var i = 0; i < a.Length; i++) {
                currentSum += a[i];
                if (currentSum > maxSum) {
                    maxSum = currentSum;
                } else if (currentSum < 0) {
                    currentSum = 0;
                }
            }
            
            return maxSum;
        }
    }
}
