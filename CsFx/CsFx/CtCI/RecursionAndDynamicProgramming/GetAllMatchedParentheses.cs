using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.RecursionAndDynamicProgramming {
    class GetAllMatchedParentheses {
        public static IList<string> Get(int n) {
            var builder = new StringBuilder(2 * n);
            var result = new List<string>();
            Get(builder, n, n, result);
            return result;
        }

        private static void Get(
            StringBuilder builder,
            int openToAdd,
            int closedToAdd,
            List<string> result) {

            if (openToAdd < 0 || closedToAdd < 0) {
                return;
            }

            if (openToAdd == 0 && closedToAdd == 0) {
                result.Add(builder.ToString());
            } else {
                if (openToAdd > 0) {
                    builder.Append("(");
                    Get(builder, openToAdd - 1, closedToAdd, result);
                    builder.Length = builder.Length - 1;
                }

                if (closedToAdd > openToAdd) {
                    builder.Append(")");
                    Get(builder, openToAdd, closedToAdd - 1, result);
                    builder.Length = builder.Length - 1;
                }
            }
        }
    }
}
