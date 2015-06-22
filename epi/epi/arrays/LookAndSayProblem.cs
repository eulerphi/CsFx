using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.arrays {
    class LookAndSayProblem {
        public static string Next(string value) {
            var result = new StringBuilder();

            var count = 1;
            var current = value.First();
            for (var i = 1; i < value.Length; i++) {
                if (value[i] == current) {
                    count++;
                } else {
                    result.Append(count);
                    result.Append(current);

                    count = 1;
                    current = value[i];
                }
            }

            result.Append(count);
            result.Append(current);

            return result.ToString();
        }
    }
}
