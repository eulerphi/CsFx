using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.ArraysAndStrings {
    class Problem5 {
        public string Solution1(string value) {
            var result = new StringBuilder(value.Length);

            var currentChar = value[0];
            var currentCharCount = 1;
            for (var i = 1; i < value.Length; i++) {
                if (value[i] == currentChar) {
                    currentCharCount++;
                } else {
                    result.Append(currentChar);
                    result.Append(currentCharCount);

                    currentChar = value[i];
                    currentCharCount = 1;
                }
            }

            result.Append(currentChar);
            result.Append(currentCharCount);

            return result.Length < value.Length
                ? result.ToString()
                : value;
        }
    }
}
