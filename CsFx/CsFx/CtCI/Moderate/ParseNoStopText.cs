using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.Moderate {
    class ParseNoStopText {
        public static int Parse(
            string sentence,
            HashSet<string> dictionary,
            int wordStart,
            int wordEnd) {

            return Parse(
                sentence,
                dictionary,
                wordStart,
                wordEnd,
                new Dictionary<int, int>());
        }

        private static int Parse(
            string sentence,
            HashSet<string> dictionary,
            int wordStart,
            int wordEnd,
            IDictionary<int, int> cache) {

            if (wordEnd >= sentence.Length) {
                return wordEnd - wordStart;
            }

            if (cache.ContainsKey(wordStart)) {
                return cache[wordStart];
            }

            var subLength = wordEnd - wordStart;
            var word = sentence.Substring(wordStart, subLength + 1);

            var bestExact = Parse(sentence, dictionary, wordEnd + 1, wordEnd + 1, cache);
            if (!dictionary.Contains(word)) {
                bestExact += word.Length;
            }

            var bestExtend = Parse(sentence, dictionary, wordStart, wordEnd + 1, cache);
            cache[wordStart] = Math.Min(bestExact, bestExtend);

            return cache[wordStart];
        }
    }
}
