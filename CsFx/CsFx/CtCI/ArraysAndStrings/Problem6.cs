using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.ArraysAndStrings {
    class Problem6 {
        public static void Solution(int[][] matrix, int n) {
            for (var layer = 0; layer < n / 2; layer++) {
                var first = layer;
                var last = n - 1 - layer;

                for (var i = first; i < last; i++) {
                    var offset = i - first;
                    
                    var top = matrix[first][i];
                    
                    // left => top
                    matrix[first][i] = matrix[last - offset][first];

                    // bottom => top
                    matrix[last - offset][first] = matrix[last][last - offset];

                    // right => bottom
                    matrix[last][last - offset] = matrix[i][last];

                    // top => right
                    matrix[i][last] = top;
                }
            }
        }
    }
}
