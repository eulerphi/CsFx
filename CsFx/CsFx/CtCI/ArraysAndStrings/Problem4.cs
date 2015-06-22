using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.ArraysAndStrings {
    class Problem4 {
        public void Solution1(char[] str, int strLength) {
            var spacesCount = 0;
            for (var i = 0; i < strLength; i++) {
                if (str[i] == ' ') {
                    spacesCount++;
                }
            }

            var endIndex = strLength + spacesCount + spacesCount - 1;
            var currentIndex = strLength - 1;

            while (currentIndex > 0) {
                if (str[currentIndex] != ' ') {
                    str[endIndex--] = str[currentIndex--];
                } else {
                    str[endIndex--] = '0';
                    str[endIndex--] = '2';
                    str[endIndex--] = '%';
                    currentIndex--;
                }
            }
            
        }
    }
}
