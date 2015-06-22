using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.SortingAndSearching {
    class MergeTwoSortedArrays {
        public static void Merge(int[] a, int[] b, int aCount) {
            if (a == null || b == null || aCount < 0 || aCount >= a.Length) {
                throw new ArgumentException();
            }

            var aIndex = aCount - 1;
            var bIndex = b.Length - 1;

            var insertIndex = aCount + b.Length - 1;
            while (aIndex >= 0 && bIndex >= 0) {
                a[insertIndex--] = a[aIndex] > b[bIndex]
                    ? a[aIndex--]
                    : b[bIndex--];
            }

            while (bIndex >= 0) {
                a[insertIndex--] = b[bIndex--];
            }
        }
    }
}
