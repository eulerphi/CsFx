using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.Hard {
    class FindDistanceBetweenWords {
        public static int Find(string[] words, string a, string b) {
            var min = Int32.MaxValue;
            var lastPositionA = -1;
            var lastPositionB = -1;

            for (var i = 0; i < words.Length; i++) {
                var current = words[i];
                if (current == a) {
                    lastPositionA = i;
                    var distance = lastPositionA - lastPositionB;
                    if (lastPositionB >= 0 && min > distance) {
                        min = distance;
                    }
                } else if (current == b) {
                    lastPositionB = i;
                    var distance = lastPositionB - lastPositionA;
                    if (lastPositionA >= 0 && min > distance) {
                        min = distance;
                    }
                }
            }

            return min;
        }
    }
}
