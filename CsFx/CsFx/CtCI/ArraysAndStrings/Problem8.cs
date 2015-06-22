using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.ArraysAndStrings {
    class Problem8 {
        public static bool IsRotaion(string a, string b) {
            return a.Length > 0
                && a.Length == b.Length
                && (a + a).Contains(b);
        }
    }
}
