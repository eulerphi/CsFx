using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.Moderate {
    class FindNumberOfTrailingZeros {
        public static int FindForFactorial(int n) {
            if (n < 0) {
                throw new ArgumentException();
            }

            var count = 0;
            for (var i = 5; n / i > 0; i *= 5) {
                count += n / 5;
            }

            return count;
        }
    }
}
