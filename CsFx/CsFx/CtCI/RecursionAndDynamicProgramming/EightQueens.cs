using CsFx.CtCI.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.RecursionAndDynamicProgramming {
    class EightQueens {
        public const int GridSize = 8;

        public static IList<int[]> Solve() {
            var columns = new int[GridSize];
            var results = new List<int[]>();
            Solve(0, columns, results);
            return results;
        }

        private static void Solve(int row, int[] columns, IList<int[]> results) {
            if (row == GridSize) {
                results.Add((int[])columns.Clone());
            } else {
                for (var col = 0; col < GridSize; col++) {
                    if (CheckValid(columns, row, col)) {
                        columns[row] = col;
                        Solve(row + 1, columns, results);
                    }
                }
            }
        }

        private static bool CheckValid(int[] columns, int row, int column) {
            for (var row2 = 0; row2 < row; row2++) {
                var column2 = columns[row2];

                var sameColumn = column == column2;
                if (sameColumn) {
                    return false;
                }

                var colDistance = Math.Abs(column2 - column);
                var rowDistance = row - row2;
                var sameDiagonal = colDistance == rowDistance;
                if (sameDiagonal) {
                    return false;
                }
            }

            return true;
        }
    }
}
