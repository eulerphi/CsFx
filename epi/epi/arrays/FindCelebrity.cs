using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.arrays {
    class FindCelebrity {
        public static void Run() {
            var table = new bool[][] {
                new bool[] { true, false, true, false, false },
                new bool[] { false, true, true, true, true },
                new bool[] { false, false, true, false, false },
                new bool[] { false, false, true, false, false },
                new bool[] { false, false, true, false, false }
            };

            var result = Find(table);
        }

        private static int Find(bool[][] table) {
            var row = 0;
            for (var col = 1; col < table.Length; col++) {
                if (table[row][col]) {
                    row = col;
                }
            }

            return row;
        }
    }
}
