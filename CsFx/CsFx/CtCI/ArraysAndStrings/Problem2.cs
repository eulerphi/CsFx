using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.ArraysAndStrings {
    class Problem2 {

        public void Solution1(char[] value) {
            var end = 0;
            var current = 0;

            if (value != null) {
                while (value[end] != '\0') {
                    end++;
                }
                end--;

                char temp;
                while (current < end) {
                    temp = value[current];
                    value[current++] = value[end];
                    value[end--] = temp;
                }
            }

        }
    }
}
