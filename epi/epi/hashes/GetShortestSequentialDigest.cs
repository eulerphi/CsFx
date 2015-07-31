using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.hashes {
    class GetShortestSequentialDigest {
        public static Tuple<int, int> Get(string[] text, string[] pattern) {
            var resultStart = 0;
            var resultEnd = 0;
            var min = Int32.MaxValue;

            var start = -1;
            var idx = 0;
            var set = new HashSet<string>(pattern);

            for (var i = 0; i < text.Length; i++) {
                var current = text[i];
                if (!set.Contains(current)) {
                    continue;
                }

                if (current != pattern[idx]) {
                    if (idx > 0) {
                        i--;
                    }
                    idx = 0;
                    continue;
                } else if (idx == 0) {
                    start = i;
                }

                idx++;
                if (pattern.Length != idx) {
                    continue;
                }

                var digestLength = i - start + 1;
                if (digestLength < min) {
                    min = digestLength;
                    resultStart = start;
                    resultEnd = i;
                }

                start = -1;
                idx = 0;
            }

            return Tuple.Create(resultStart, resultEnd);
        }

        public static Tuple<int, int> GetBook(string[] text, string[] pattern) {
            var keywordToIndex = new Dictionary<string, int>();
            for (var i = 0; i < pattern.Length; i++) {
                keywordToIndex[pattern[i]] = i;
            }

            var latestOccurrence = Enumerable.Repeat(-1, pattern.Length).ToList();
            var shortestSubarrayLength = Enumerable.Repeat(Int32.MaxValue, pattern.Length).ToList();

            var start = -1;
            var end = -1;
            var min = Int32.MaxValue;
            for (var i = 0; i < text.Length; i++) {
                var current = text[i];
                if (!keywordToIndex.ContainsKey(current)) {
                    continue;
                }

                var idx = keywordToIndex[current];
                if (idx == 0) {
                    shortestSubarrayLength[idx] = 1;
                } else if (shortestSubarrayLength[idx - 1] != Int32.MaxValue) {
                    var distanceToPreviousKeyword = i - latestOccurrence[idx - 1];
                    shortestSubarrayLength[idx] = distanceToPreviousKeyword + shortestSubarrayLength[idx - 1];
                }

                latestOccurrence[idx] = i;
                var length = shortestSubarrayLength.Last();
                if (length < min) {
                    min = length;
                    start = latestOccurrence.First();
                    end = latestOccurrence.Last();
                }
            }

            return Tuple.Create(start, end);
        }

        public static Tuple<int, int> GetBrute(string[] text, string[] pattern) {
            var result = Tuple.Create(-1, -1);
            var resultLength = Int32.MaxValue;

            for (var start = 0; start < text.Length; start++) {
                for (var end = start + 1; end < text.Length; end++) {
                    var patternIndex = 0;
                    for (var i = start; i <= end && patternIndex < pattern.Length; i++) {
                        if (text[i] == pattern[patternIndex]) {
                            patternIndex++;
                        }
                    }

                    var foundPattern = pattern.Length == patternIndex;
                    var digestLength = end - start;
                    if (foundPattern && digestLength < resultLength) {
                        result = Tuple.Create(start, end);
                        resultLength = digestLength;
                    }
                }
            }

            return result;
        }

        public static Tuple<int, int> GetBrute2(string[] text, string[] pattern) {
            var result = Tuple.Create(-1, -1);
            var resultLength = Int32.MaxValue;

            for (var start = 0; start < text.Length; start++) {
                var patternIndex = 0;
                var end = start;
                for (; end < text.Length && patternIndex < pattern.Length; end++) {
                    if (text[end] == pattern[patternIndex]) {
                        patternIndex++;
                    }
                }

                var foundPattern = pattern.Length == patternIndex;
                var digestLength = end - start;
                if (foundPattern && digestLength < resultLength) {
                    result = Tuple.Create(start, end);
                    resultLength = digestLength;
                }
            }

            return result;
        }
    }
}
