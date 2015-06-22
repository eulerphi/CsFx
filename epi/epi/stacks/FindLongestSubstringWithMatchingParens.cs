using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.stacks {
    class FindLongestSubstringWithMatchingParens {
        public static Tuple<int, int> Find(string s) {
            var maxStartIndex = -1;
            var maxEndIndex = -1;
            var maxLength = 0;
            var parens = new Stack<ParenInfo>();
            var matched = new Stack<MatchedInfo>();

            for (var i = 0; i < s.Length; i++) {
                var currentParen = new ParenInfo(s[i], i);

                var newMatched = currentParen.Close && parens.Count > 0 && parens.Peek().Open;

                if (!newMatched) {
                    parens.Push(currentParen);
                } else {
                    var startParen = parens.Pop();
                    var currentMatched = new MatchedInfo(startParen, currentParen);
                    while (matched.Any() && currentMatched.CanExtend(matched.Peek())) {
                        currentMatched = currentMatched.Extend(matched.Pop());
                    }

                    if (currentMatched.Length > maxLength) {
                        maxStartIndex = currentMatched.Start;
                        maxEndIndex = currentMatched.End;
                        maxLength = currentMatched.Length;
                    }

                    matched.Push(currentMatched);
                }
            }

            return Tuple.Create(maxStartIndex, maxEndIndex);
        }

        class ParenInfo {
            public bool Open { get; private set; }
            public bool Close { get; private set; }
            public int Index { get; private set; }

            public ParenInfo(char c, int index) {
                this.Open = c == '(';
                this.Close = !this.Open;
                this.Index = index;
            }
        }

        class MatchedInfo {
            public int Start { get; private set; }
            public int End { get; private set; }
            public int Length { get { return this.End - this.Start; } }

            public MatchedInfo(int start, int end) {
                this.Start = start;
                this.End = end;
            }

            public MatchedInfo(ParenInfo start, ParenInfo end) : this(start.Index, end.Index) {
                // empty
            }

            public bool CanExtend(MatchedInfo other) {
                return other.End >= this.Start - 1
                    && other.End < this.End;
            }

            public MatchedInfo Extend(MatchedInfo other) {
                return new MatchedInfo(
                    Math.Min(this.Start, other.Start),
                    Math.Max(this.End, other.End));
            }
        }
    }
}
