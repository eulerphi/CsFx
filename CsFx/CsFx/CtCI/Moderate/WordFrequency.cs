using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.Moderate {
    class WordFrequency {
        private readonly IDictionary<string, int> wordCounts;

        public WordFrequency(string[] book) {
            if (book == null) {
                throw new ArgumentNullException();
            }

            this.wordCounts = PreprocessBook(book);
        }

        public int Count(string word) {
            if (String.IsNullOrWhiteSpace(word)) {
                throw new ArgumentNullException();
            }
            
            return this.wordCounts.ContainsKey(word)
                ? this.wordCounts[word]
                : 0;
        }

        private static IDictionary<string, int> PreprocessBook(string[] book) {
            var wordCounts = new Dictionary<string, int>();
            
            foreach (var word in book) {
                if (!wordCounts.ContainsKey(word)) {
                    wordCounts[word] = 0;
                }

                wordCounts[word]++;
            }

            return wordCounts;
        }
    }
}
