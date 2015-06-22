using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.SortingAndSearching {
    class FindInArrayWithEmptyStrings {
        public static int Find(string[] a, string value) {
            if (a == null || String.IsNullOrEmpty(value)) {
                throw new ArgumentNullException();
            }

            return Find(a, value, 0, a.Length - 1);
        }

        private static int Find(string[] a, string value, int left, int right) {
            if (left > right) {
                return -1;
            }

            var mid = (left + right) / 2;
            if (a[mid] == String.Empty) {
                var midLeft = mid - 1;
                var midRight = mid + 1;
                while (true) {
                    if (midLeft < left && midRight > right) {
                        return -1;
                    } else if (midLeft >= left && a[midLeft] != String.Empty) {
                        mid = midLeft;
                        break;
                    } else if (midRight <= right && a[midRight] != String.Empty) {
                        mid = midRight;
                        break;
                    }

                    midLeft--;
                    midRight++;
                }
            }

            if (a[mid] == value) {
                return mid;
            }

            var isValueGreaterThanMid = a[mid].CompareTo(value) < 0;
            return isValueGreaterThanMid
                ? Find(a, value, mid + 1, right)
                : Find(a, value, left, mid - 1);
        }
    }
}
