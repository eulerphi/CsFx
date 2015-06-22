using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.SortingAndSearching {
    class FindInRotatedArray {
        public static int Find(int[] a, int value) {
            if (a == null) {
                throw new ArgumentNullException();
            }

            return Find(a, value, 0, a.Length - 1);
        }

        private static int Find(int[] a, int value, int left, int right) {
            if (left > right) {
                return -1;
            }

            var mid = (left + right) / 2;
            if (a[mid] == value) {
                return mid;
            }

            int result;
            if (a[mid] > a[left]) {
                result = value >= a[left] && a[mid] >= value
                    ? Find(a, value, left, mid - 1)
                    : Find(a, value, mid + 1, right);
            } else if (a[left] > a[mid]) {
                result = value >= a[mid] && a[right] >= value
                    ? Find(a, value, mid + 1, right)
                    : Find(a, value, left, mid + 1);
            } else { // a[left] == a[mid]
                if (a[mid] != a[right]) {
                    result = Find(a, value, mid + 1, right);
                } else {
                    result = Find(a, value, left, mid - 1);
                    if (result < 0) {
                        result = Find(a, value, mid + 1, right);
                    }
                }
            }

            return result;
        }
    }
}
