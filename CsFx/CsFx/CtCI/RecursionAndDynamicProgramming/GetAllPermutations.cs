using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.RecursionAndDynamicProgramming {
    class GetAllPermutations {
        public static IList<string> Get(string value) {
            if (value == null) {
                throw new ArgumentNullException();
            }

            if (value.Length == 0) {
                return new List<string> { String.Empty };
            }

            var permutations = new List<string>();

            var first = value.Substring(0, 1);
            var remainder = value.Substring(1);
            var remainderPermutations = Get(remainder);
            foreach (var p in remainderPermutations) {
                for (var i = 0; i <= p.Length; i++) {
                    permutations.Add(p.Insert(i, first));
                }
            }

            return permutations;
        }
    }
}
