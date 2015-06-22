using CsFx.CtCI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.Moderate {
    class FindSubsequenceToSort {
        public static Pair Find(int[] a) {
            if (a == null) {
                throw new ArgumentNullException();
            }

            var leftEnd = FindEndOfSortedLeft(a);
            var rightStart = FindStartOfSortedRight(a);

            var midMinIndex = leftEnd + 1;
            if (midMinIndex >= a.Length) {
                return new Pair(-1, -1);
            }

            var midMaxIndex = rightStart - 1;
            for (var i = leftEnd; i <= rightStart; i++) {
                if (a[i] < a[midMinIndex]) {
                    midMinIndex = i;
                }

                if (a[i] > a[midMaxIndex]) {
                    midMaxIndex = i;
                }
            }

            var sortLeftIndex = ShrinkLeft(a, leftEnd, midMinIndex);
            var sortRightIndex = ShrinkRight(a, rightStart, midMaxIndex);

            return new Pair(sortLeftIndex, sortRightIndex);
        }

        private static int FindEndOfSortedLeft(int[] a) {
            for (var i = 1; i < a.Length; i++) {
                if (a[i - 1] > a[i]) {
                    return i - 1;
                }
            }

            return a.Length - 1;
        }

        private static int FindStartOfSortedRight(int[] a) {
            for (var i = a.Length - 2; i >= 0; i--) {
                if (a[i] > a[i + 1]) {
                    return i + 1;
                }
            }

            return 0;
        }

        private static int ShrinkLeft(int[] a, int leftEnd, int midMinIndex) {
            var comp = a[midMinIndex];
            for (var i = leftEnd - 1; i >= 0; i--) {
                if (a[i] <= comp) {
                    return i + 1;
                }
            }

            return 0;
        }

        private static int ShrinkRight(int[] a, int rightStart, int midMaxIndex) {
            var comp = a[midMaxIndex];
            for (var i = rightStart + 1; i < a.Length; i++) {
                if (a[i] >= comp) {
                    return i - 1;
                }
            }

            return a.Length - 1;
        }
    }
}
