using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.Moderate {
    class FindMax {
        public static int Max(int a, int b) {
            int c = a - b;

            int sa = Sign(a);
            int sb = Sign(b);
            int sc = Sign(c);

            var useA = sa ^ sb;
            var useC = Flip(sa ^ sb);

            var k = useA * sa + useC * sc;
            var q = Flip(k);

            return a * k + b * q;
        }

        private static int Sign(int a) {
            return Flip((a >> 31) & 0x1);
        }

        private static int Flip(int a) {
            return 1^a;
        }
    }
}
