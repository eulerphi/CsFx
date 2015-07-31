using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.arrays {
    class JustifyText {
        public static void Run() {
            var input = "Thererere quick brown fox jumped over the lazy dog.".Split(' ');
            var len = 11;
            var result = Justify2(input, len);
        }

        #region Version 1
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
        #endregion

        #region Version 2
        public static IList<string> Justify2(string[] words, int maxLen) {
            var result = new List<string>();

            var line = new Line(words, 0, maxLen);

            for (var i = 1; i < words.Length; i++) {
                if (!line.TryAddWord(i)) {
                    result.Add(line.Justify(GetLineSpaces));
                    line = new Line(words, i, maxLen);
                }
            }

            result.Add(line.Justify(GetLastLineSpaces));

            return result;
        }

        private static IEnumerable<int> GetLineSpaces(int numWords, int len, int maxLen) {
            var numGaps = numWords - 1;
            var spacesLeft = maxLen - len + numGaps;

            for (var i = 0; i < numGaps; i++) {
                var numSpaces = spacesLeft / (numGaps - i);
                numSpaces += spacesLeft % (numGaps - i) != 0 ? 1 : 0;
                spacesLeft -= numSpaces;
                yield return numSpaces;
            }

            yield return spacesLeft;
        }

        private static IEnumerable<int> GetLastLineSpaces(int numWords, int len, int maxLen) {
            var numGaps = numWords - 1;
            var last = maxLen - len;
            return Enumerable
                .Repeat(1, numGaps)
                .Concat(new[] { last })
                .ToArray();
        }

        private class Line {
            private string[] words;
            private int start, end, curLen, maxLen;

            public Line(string[] words, int start, int maxLen) {
                this.words = words;
                this.start = start;
                this.end = start;
                this.curLen = words[start].Length;
                this.maxLen = maxLen;

                if (this.curLen > this.maxLen) {
                    throw new ArgumentException();
                }
            }

            public bool TryAddWord(int i) {
                var newLen = curLen + words[i].Length + 1;

                var canAdd = newLen <= maxLen;
                if (canAdd) {
                    curLen = newLen;
                    end = i;
                }

                return canAdd;
            }

            public string Justify(Func<int, int, int, IEnumerable<int>> getSpaces) {
                var builder = new StringBuilder();

                var numWords = end - start + 1;
                var spaces = getSpaces(numWords, curLen, maxLen);
                var pairs = words.Skip(start).Take(numWords).Zip(spaces, Tuple.Create);
                foreach (var p in pairs) {
                    builder.Append(p.Item1);
                    builder.Append(' ', p.Item2);
                }

                return builder.ToString();
            }
        }
        #endregion
    }
}
