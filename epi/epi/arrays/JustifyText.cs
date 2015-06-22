using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.arrays {
    class JustifyText {
        public static IList<string> Justify(string[] words, int maxLineLength) {
            var lines = new List<string>();

            var start = 0;
            var length = words[0].Length;
            for (var i = 1; i < words.Length; i++) {
                var newLength = length + words[i].Length + 1;
                if (newLength <= maxLineLength) {
                    length = newLength;
                } else {
                    lines.Add(JustifyLine(words, start, i - 1, length, maxLineLength));
                    start = i;
                    length = words[i].Length;
                }
            }

            if (length > 0) {
                lines.Add(JustifyLastLine(words, start, words.Length - 1, length, maxLineLength));
            }

            return lines;
        }

        private static string JustifyLastLine(string[] words, int start, int end, int length, int maxLineLength) {
            var numWords = end - start + 1;
            var numWordGaps = numWords - 1;
            var numTrainlingSpaces = maxLineLength - length;

            var builder = new StringBuilder();
            for (var i = start; i < end; i++) {
                builder.Append(words[i]);
                builder.Append(" ");
            }

            builder.Append(words[end]);
            for (var i = 0; i < numTrainlingSpaces; i++) {
                builder.Append(" ");
            }

            return builder.ToString();
        }

        private static string JustifyLine(string[] words, int start, int end, int length, int maxLineLength) {
            var numWords = end - start + 1;
            var numWordGaps = numWords - 1;
            var numSpaces = maxLineLength - length + numWordGaps;
            var average = numSpaces / numWordGaps;
            var remainder = numSpaces % numWordGaps;

            var builder = new StringBuilder();
            for (var i = start; i < end; i++) {
                builder.Append(words[i]);
                for (var j = 0; j < average; j++) {
                    builder.Append(" ");
                }

                if (remainder > 0) {
                    builder.Append(" ");
                    remainder--;
                }
            }

            builder.Append(words[end]);
            return builder.ToString();
        }
    }
}
