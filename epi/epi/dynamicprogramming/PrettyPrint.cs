using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.dynamicprogramming {
    class PrettyPrint {
        public static int GetMinMessiness(string[] words, int lineLength) {
            var rowTemplate = Enumerable.Repeat(Double.MaxValue, words.Length + 1);
            var table = new List<List<double>>();
            for (var i = 0; i <= words.Length; i++) {
                table.Add(rowTemplate.ToList());
            }

            var wordLengths = new List<int>();
            wordLengths.Add(words[0].Length);
            for (var i = 1; i < words.Length; i++) {
                wordLengths.Add(wordLengths[i - 1] + words[i].Length + 1);
            }

            for (var j = 0; j < words.Length; j++) {
                var spacesRemaining = lineLength - wordLengths[j];
                if (spacesRemaining >= 0) {
                    table[0][j + 1] = Math.Pow(2, spacesRemaining);
                }
            }

            for (var i = 1; i < words.Length; i++) {
                for (var j = 0; j < words.Length; j++) {
                    if (i + j >= wordLengths.Count) {
                        break;
                    }

                    var spacesRemaining = lineLength - (wordLengths[i + j] - wordLengths[j]);
                    if (spacesRemaining >= 0) {
                        table[i][j + 1] = Math.Pow(2, spacesRemaining)
                                        + table[i - 1][j + 1];
                    }
                }
            }

            return 0;
        }

        public static long GetMinMessinessBook(string[] words, int lineLength) {
            var table = Enumerable.Repeat(Int64.MaxValue, words.Length).ToList();
            for (var i = 0; i < words.Length; i++) {
                var b_len = lineLength - words[i].Length;
                var messiness = ((long)1) << b_len;
                table[i] = Math.Min(i < 1 ? 0 : table[i - 1] + messiness, table[i]);
                for (var j = i - 1; j >= 0; j--) {
                    b_len -= words[j].Length + 1;
                    if (b_len < 0) {
                        break;
                    }

                    messiness = ((long)1) << b_len;
                    table[i] = Math.Min(j - 1 < 0 ? 0 : table[j - 1] + messiness, table[i]);
                }
            }


            long minMess = words.Length >= 2 ? table[words.Length - 2] : 0;
            var c_len = lineLength - words.Last().Length;
            for (var i = words.Length - 2; i >= 0; i--) {
                c_len -= words[i].Length + 1;
                if (c_len < 0) {
                    return minMess;
                }

                minMess = Math.Min(minMess, i < 1 ? 0 : table[i - 1]);
            }

            return minMess;
        }
    }
}
