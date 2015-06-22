using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.dynamicprogramming {
    class IsInterleaving {
        public static bool Check(string s1, string s2, string t) {
            if (s1 == "") {
                return t == s2;
            } else if (s2 == "") {
                return t == s1;
            } else if (s1[0] == t[0]) {
                return Check(s1.Substring(1), s2, t.Substring(1));
            } else if (s2[0] == t[0]) {
                return Check(s1, s2.Substring(1), t.Substring(1));
            } else {
                return false;
            }
        }

        public static bool CheckBook(string s1, string s2, string t) {
            if (s1.Length + s2.Length != t.Length) {
                return false;
            }

            var table = new List<List<bool>>();
            var rowTemplate = Enumerable.Repeat(false, s2.Length + 1);
            for (var i = 0; i <= s1.Length; i++) {
                table.Add(rowTemplate.ToList());
            }

            for (var i = 0; i < s1.Length; i++) {
                if (s1[i] == t[i]) {
                    table[i + 1][0] = true;
                } else {
                    break;
                }
            }


            for (var i = 0; i < s1.Length; i++) {
                if (s2[i] == t[i]) {
                    table[0][i + 1] = true;
                } else {
                    break;
                }
            }

            for (var i = 0; i < s1.Length; i++) {
                for (var j = 0; j < s2.Length; j++) {
                    var matchS1 = table[i][j + 1] && s1[i] == t[i + j + 1];
                    var matchS2 = table[i + 1][j] && s2[j] == t[i + j + 1];
                    table[i + 1][j + 1] = matchS1 || matchS2;
                }
            }

            return table[s1.Length][s2.Length];
        }
    }
}
