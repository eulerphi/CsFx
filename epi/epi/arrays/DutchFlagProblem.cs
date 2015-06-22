using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.arrays {
    class DutchFlagProblem {
        public static void Sort(int[] a, int partitionIndex) {
            var lt = 0;
            var gt = a.Length - 1;

            var pValue = a[partitionIndex];

            a[partitionIndex] = a[0];
            a[0] = pValue;

            var i = 1;
            while (i <= gt) {
                if (pValue == a[i]) i++;
                else if (pValue > a[i]) Exchange(a, i++, lt++);
                else Exchange(a, i, gt--);
            }
        }

        private static void Exchange(int[] a, int i, int j) {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }

    class DutchFlagProblemVariant1 {
        public static void Sort(int[] a) {
            var aValue = a[0];
            var aInsert = 1;

            var bValueSet = false;
            var bValue = 0;
            var bInsert = a.Length - 1;

            var i = 1;
            while (i <= bInsert) {
                if (a[i] == aValue) {
                    Exchange(a, i++, aInsert++);
                    continue;
                }

                if (!bValueSet) {
                    bValue = a[i];
                    bValueSet = true;
                }

                if (a[i] == bValue) {
                    Exchange(a, i++, bInsert--);
                } else {
                    i++;
                }
            }
        }

        private static void Exchange(int[] a, int i, int j) {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }

    class DutchFlagProblemVariant2 {
        public static void Sort(int[] a) {
            var aValue = a[0];
            var aInsert = 1;

            var bValueSet = false;
            var bValue = 0;
            var bInsert = a.Length - 1;

            var cValueSet = false;
            var cValue = 0;
            var cInsert = 0;

            var i = 1;
            while (i < a.Length && (!bValueSet || i <= bInsert) && (!cValueSet || i <= cInsert)) {
                Console.WriteLine("i: " + i);
                var info = new String(' ', a.Length).ToArray();
                info[aInsert] = aValue.ToString()[0];
                if (bValueSet) {
                    info[bInsert] = bValue.ToString()[0];
                }

                if (cValueSet) {
                    info[cInsert] = cValue.ToString()[0];
                }

                Console.WriteLine(String.Join(", ", info));
                Console.WriteLine(String.Join(", ", a));
                if (a[i] == aValue) {
                    Exchange(a, i++, aInsert++);
                } else {
                    if (bValueSet && a[i] != bValue && !cValueSet) {
                        cValue = a[i];
                        cInsert = bInsert;
                        cValueSet = true;
                    }

                    if (!bValueSet) {
                        bValue = a[i];
                        bValueSet = true;
                    }

                    if (a[i] == bValue) {
                        Exchange(a, i, bInsert--);
                        if (cValueSet) {
                            Exchange(a, i, cInsert--);
                        }
                    } else if (cValueSet && a[i] == cValue) {
                        Exchange(a, i, cInsert--);
                    } else {
                        i++;
                    }
                }


                Console.WriteLine(String.Join(", ", a));

                info = new String(' ', a.Length).ToArray();
                info[aInsert] = aValue.ToString()[0];
                if (bValueSet) {
                    info[bInsert] = bValue.ToString()[0];
                }

                if (cValueSet) {
                    info[cInsert] = cValue.ToString()[0];
                }
                Console.WriteLine(String.Join(", ", info));
                Console.WriteLine("---------");
            }
        }

        private static void Exchange(int[] a, int i, int j) {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }

    class DutchFlagProblemVariant3 {
        public static void Sort(bool[] a) {
            var trueInsert = a.Length - 1;

            var i = 0;
            while (i < trueInsert) {
                if (a[i]) {
                    Exchange(a, i, trueInsert--);
                } else {
                    i++;
                }
            }
        }

        private static void Exchange(bool[] a, int i, int j) {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }

    class DutchFlagProblemVariant4 {
        public static void Sort(bool[] a) {
            var trueInsert = 0;
            var trueCount = 0;

            var i = 0;
            while (i < a.Length) {
                if (a[i]) {
                    Exchange(a, i++, trueInsert++);
                    trueCount++;
                } else {
                    i++;
                }
            }

            var falseCount = a.Length - trueCount;
            for (var j = 0; j < trueCount; j++) {
                Exchange(a, j, falseCount + j);
            }
        }

        private static void Exchange(bool[] a, int i, int j) {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}
