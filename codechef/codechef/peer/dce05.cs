using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codechef.peer {
    class dce05 {
        public static void Run(string[] args) {
            var num = int.Parse(Console.ReadLine());
            for (var i = 0; i < num; i++) {
                var input = int.Parse(Console.ReadLine());
                var log = (int)Math.Log(input, 2);
                Console.WriteLine((int)Math.Pow(2, log));
            }
        }
    }
}
