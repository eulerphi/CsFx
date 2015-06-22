using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.Moderate {
    enum MasterMindColor {
        Red,
        Yellow,
        Green,
        Blue
    }

    class MasterMindResult : Tuple<int, int> {
        public int Hits { get { return this.Item1; } }
        public int PseudoHits { get { return this.Item2; } }

        public MasterMindResult(int hits, int pseudoHits) : base(hits, pseudoHits) {
            // empty
        }
    }

    class MasterMind {
        public const int CombinationLength = 4;

        public static MasterMindResult Check(
            MasterMindColor[] guess, MasterMindColor[] solution) {

            if (guess == null || guess.Length != CombinationLength) {
                throw new ArgumentException();
            }

            if (solution == null || solution.Length != CombinationLength) {
                throw new ArgumentException();
            }

            var pseudoHitCandidates = Enum
                .GetValues(typeof(MasterMindColor))
                .OfType<MasterMindColor>()
                .ToDictionary(c => c, _ => 0);

            var hits = 0;
            for (var i = 0; i < CombinationLength; i++) {
                if (guess[i] == solution[i]) {
                    hits++;
                } else {
                    pseudoHitCandidates[solution[i]]++;
                }
            }

            var pseudoHits = 0;
            for (var i = 0; i < CombinationLength; i++) {
                if (guess[i] == solution[i]) {
                    continue;
                }

                if (pseudoHitCandidates[guess[i]] == 0) {
                    continue;
                }

                pseudoHits++;
                pseudoHitCandidates[guess[i]]--;
            }

            return new MasterMindResult(hits, pseudoHits);
        }
    }
}
