using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.Moderate {
    class Rand7 {
        public static int Next() {
            var rand = new Random();
            
            while (true) {
                var num = 5 * rand.Next(5) + rand.Next(5);
                if (num < 21) {
                    return num % 7;
                }
            }
        }
    }
}
