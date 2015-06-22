using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.RecursionAndDynamicProgramming {
    class FindMagicIndex {
        public static int FindDistinct(int[] array) {
            if (array == null) {
                throw new ArgumentNullException("array");
            }

            return FindDistinct(array, 0, array.Length - 1);
        }

        private static int FindDistinct(int[] array, int startIndex, int endIndex) {
            if (startIndex < 0 || endIndex >= array.Length || startIndex > endIndex) {
                return -1;
            }

            var midIndex = (startIndex + endIndex) / 2;
            var midValue = array[midIndex];
            if (midValue == midIndex) {
                return midIndex;
            }

            return midValue > midIndex
                ? FindDistinct(array, startIndex, midIndex - 1)
                : FindDistinct(array, midIndex + 1, endIndex);
        }

        public static int Find(int[] array) {
            if (array == null) {
                throw new ArgumentNullException("array");
            }

            return Find(array, 0, array.Length - 1);

        }

        private static int Find(int[] array, int startIndex, int endIndex) {
            if (startIndex < 0 || endIndex >= array.Length || startIndex > endIndex) {
                return -1;
            }

            var midIndex = (startIndex + endIndex) / 2;
            var midValue = array[midIndex];
            if (midValue == midIndex) {
                return midIndex;
            }

            var leftEndIndex = Math.Min(midIndex - 1, midValue);
            var left = Find(array, startIndex, leftEndIndex);
            if (left >= 0) {
                return left;
            }

            var rightStartIndex = Math.Max(midIndex + 1, midValue);
            return Find(array, rightStartIndex, endIndex);
        }
    }
}
