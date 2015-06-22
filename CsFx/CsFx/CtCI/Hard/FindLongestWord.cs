using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.Hard {
    class FindLongestWord {
        public static string Find(string[] words) {
            var map = words.ToDictionary(w => w, w => true);

            var sorted = words
                .OrderByDescending(w => w.Length)
                .ToList();

            foreach (var s in sorted) {
                if (CanBuildWord(s, true, map)) {
                    return s;
                }
            }

            return String.Empty;
        }

        private static bool CanBuildWord(
            string word,
            bool isOriginalWord,
            Dictionary<string, bool> map) {

            if (map.ContainsKey(word) && !isOriginalWord) {
                return map[word];
            }

            for (var i = 1; i < word.Length; i++) {
                var left = word.Substring(0, i);
                var right = word.Substring(i);
                if (map.ContainsKey(left) && map[left] && CanBuildWord(right, false, map)) {
                    return true;
                }
            }

            map[word] = false;
            return false;
        }
    }
}
