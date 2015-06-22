using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.ArraysAndStrings {
    class Problem7 {
        public static void Solution(int[][] matrix) {
            var rowsToZero = new HashSet<int>();
            var columnsToZero = new HashSet<int>();

            for (var row = 0; row < matrix.Length; row++) {
                for (var column = 0; column < matrix[row].Length; column++) {
                    if (matrix[row][column] == 0) {
                        rowsToZero.Add(row);
                        columnsToZero.Add(column);
                    }
                }
            }

            for (var row = 0; row < matrix.Length; row++) {
                var shouldZeroRow = rowsToZero.Contains(row);

                for (var column = 0; column < matrix[row].Length; column++) {
                    var shouldZeroCell = shouldZeroRow
                        || columnsToZero.Contains(column);

                    if (shouldZeroCell) {
                        matrix[row][column] = 0;
                    }
                }
            }
        }
    }
}
