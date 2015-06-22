using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.SortingAndSearching {
    class SortAnagrams {
        public static void Sort(string[] words) {
            if (words == null) {
                throw new ArgumentNullException();
            }

            var map = new Dictionary<string, List<string>>();
            foreach (var w in words) {
                var sorted = Sort(w);
                
                if (!map.ContainsKey(sorted)) {
                    map[sorted] = new List<string>();
                }

                map[sorted].Add(w);
            }

            var i = 0;
            foreach (var w in map.SelectMany(kvp => kvp.Value)) {
                words[i++] = w;
            }
        }

        private static string Sort(string w) {
            var chars = w.ToArray();
            Array.Sort(chars);
            return new string(chars);
        }
    }
}
