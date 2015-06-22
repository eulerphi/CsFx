using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.Hard {
    class Shuffle {
        public static void Do(int[] cards, int seed) {
            var random = new Random(seed);

            for (var i = 0; i < cards.Length; i++) {
                var index = i + random.Next(cards.Length - i);
                var temp = cards[i];
                cards[i] = cards[index];
                cards[index] = temp;
            }
        }
    }
}
