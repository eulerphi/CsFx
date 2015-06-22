using CsFx.CtCI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.SortingAndSearching {
    class FindSubsequenceOfPairs {
        public static IList<Pair> FindLongest(IList<Pair> pairs) {
            if (pairs == null) {
                throw new ArgumentNullException();
            }

            var sortedPairs = pairs
                .OrderBy(p => p.Fst)
                .ThenBy(p => p.Snd)
                .ToList();

            var solutions = new List<Pair>[sortedPairs.Count];
            FindSolutions(sortedPairs, solutions, 0);

            IList<Pair> bestSolution = null;
            foreach (var solution in solutions) {
                bestSolution = MaxSequence(bestSolution, solution);
            }

            return bestSolution;
        }

        private static void FindSolutions(
            IList<Pair> pairs, IList<Pair>[] solutions, int currentIndex) {

            if (currentIndex >= pairs.Count) {
                return;
            }

            var currentElement = pairs[currentIndex];

            IList<Pair> bestSequence = null;
            for (var i = 0; i < currentIndex; i++) {
                if (pairs[i].IsLessThan(currentElement)) {
                    bestSequence = MaxSequence(bestSequence, solutions[i]);
                }
            }

            var currentSolution = new List<Pair>();
            if (bestSequence != null) {
                currentSolution.AddRange(bestSequence);
            }

            currentSolution.Add(currentElement);
            solutions[currentIndex] = currentSolution;

            FindSolutions(pairs, solutions, currentIndex + 1);
        }

        private static IList<Pair> MaxSequence(IList<Pair> a, IList<Pair> b) {
            if (a == null) return b;
            if (b == null) return a;

            return a.Count > b.Count ? a : b;
        }

    }
}
