using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.hashes {
    class GetShortestDigest {
        public static Tuple<int, int> Get(string[] text, ISet<string> words) {
            var resultStart = 0;
            var resultEnd = 0;
            var min = Int32.MaxValue;

            var count = words.Count;
            var digest = new LinkedList<int>();
            var wordToNode = new Dictionary<string, LinkedListNode<int>>();
            for (var i = 0; i < text.Length; i++) {
                var current = text[i];
                if (!words.Contains(current)) {
                    continue;
                }

                if (!wordToNode.ContainsKey(current)) {
                    count--;
                } else {
                    var node = wordToNode[current];
                    digest.Remove(node);
                }

               
                wordToNode[current] =  digest.AddLast(i);
                if (count > 0) {
                    continue;
                }

                var start = digest.First.Value;
                var end = digest.Last.Value;
                var digestLength = end - start + 1;
                if (digestLength < min) {
                    min = digestLength;
                    resultStart = start;
                    resultEnd = end;
                }
            }

            return Tuple.Create(resultStart, resultEnd);
        }
    }
}
