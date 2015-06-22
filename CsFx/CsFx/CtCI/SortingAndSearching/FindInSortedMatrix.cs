using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.SortingAndSearching {
    class FindInSortedMatrix {
        public static Tuple<int, int> Find(int[][] m, int value) {
            if (m == null) {
                throw new ArgumentNullException();
            }

            var row = 0;
            var col = m[row].Length - 1;
            while (row < m.Length && col >= 0) {
                var cell = m[row][col];
                if (cell == value) {
                    return Tuple.Create(row, col);
                } else if (cell > value) {
                    col--;
                } else { // value > cell
                    row++;
                }
            }

            return Tuple.Create(-1, -1);
        }
    }
}
