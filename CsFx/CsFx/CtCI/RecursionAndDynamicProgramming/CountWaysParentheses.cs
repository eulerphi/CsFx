using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.RecursionAndDynamicProgramming {
    class CountWaysParentheses {
        public const char One = '1';
        public const char Zero = '0';
        public const char And = '&';
        public const char Or = '|';
        public const char Xor = '^';


        public static int CountTrue(string expression) {
            if (expression == null) {
                throw new ArgumentNullException();
            }

            return Count(
                expression,
                true,
                0,
                expression.Length - 1,
                new Dictionary<Tuple<bool,int,int>,int>());
        }

        public static int CountFalse(string expression) {
            if (expression == null) {
                throw new ArgumentNullException();
            }

            return Count(
                expression,
                false,
                0,
                expression.Length - 1,
                new Dictionary<Tuple<bool,int,int>,int>());
        }

        private static int Count(
            string expression,
            bool result,
            int start,
            int end,
            Dictionary<Tuple<bool, int, int>, int> cache) {

            var cacheKey = Tuple.Create(result, start, end);

            if (cache.ContainsKey(cacheKey)) {
                return cache[cacheKey];
            }

            if (start == end) {
                var expectedResult = (expression[start] == One && result)
                                  || (expression[start] == Zero && !result);

                return expectedResult ? 1 : 0;
            }

            var ways = 0;

            // NOTE : Assumes the expression is well-formed, i.e. there is
            // no whitespace in the expression
            for (var i = start + 1; i <= end; i += 2) {
                ways += result
                    ? CountTrue(expression, start, end, i, cache)
                    : CountFalse(expression, start, end, i, cache);
            }

            cache[cacheKey] = ways;
            return ways;
        }

        private static int CountTrue(
            string expression,
            int start,
            int end,
            int current,
            Dictionary<Tuple<bool, int, int>, int> cache) {

            var maybeOp = expression[current];
            var helper = CountHelper(expression, start, end, current, cache);


            if (maybeOp == And) {
                return helper(true, true);
            } else if (maybeOp == Or) {
                return helper(true, true) +
                       helper(true, false) +
                       helper(false, true);
            } else if (maybeOp == Xor) {
                return helper(true, false) +
                       helper(false, true);
            } else {
                return 0;
            }
        }

        private static int CountFalse(
            string expression,
            int start,
            int end,
            int current,
            Dictionary<Tuple<bool, int, int>, int> cache) {

            var maybeOp = expression[current];
            var helper = CountHelper(expression, start, end, current, cache);

            if (maybeOp == And) {
                return helper(true, false) +
                       helper(false, true) +
                       helper(false, false);
            } else if (maybeOp == Or) {
                return helper(false, false);
            } else if (maybeOp == Xor) {
                return helper(true, true) +
                       helper(false, false);
            } else {
                return 0;
            }
        }

        private static Func<bool, bool, int> CountHelper(
            string expression,
            int start,
            int end,
            int current,
            Dictionary<Tuple<bool, int, int>, int> cache) {

            var leftStart = start;
            var leftEnd = current - 1;
            var rightStart = current + 1;
            var rightEnd = end;

            return (leftResult, rightResult) =>
                Count(expression, leftResult, leftStart, leftEnd, cache) *
                Count(expression, rightResult, rightStart, rightEnd, cache);
        }
    }
}
