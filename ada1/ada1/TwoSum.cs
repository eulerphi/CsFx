using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ada1 {
    class TwoSum {
        public static void Run() {
            long tmin = -10000;
            long tmax = 10000;
            long tdiff = tmax - tmin;

            var xs = File.ReadLines("P6_2Sum.txt").Select(long.Parse).Distinct().ToList();
            var map = new Dictionary<long, IList<long>>();
            foreach (var x in xs) {
                var key = x / tdiff;
                if (!map.ContainsKey(key)) {
                    map[key] = new List<long>();
                }

                map[key].Add(x);
            }

            var seen = new HashSet<long>();

            var count = 0;
            foreach (var x in xs) {
                var ymin = checked(tmin - x);
                var ymax = checked(tmax - x);
                for (var key = ymin / tdiff; key <= ymax / tdiff; key++) {
                    if (!map.ContainsKey(key)) {
                        continue;
                    }

                    var ts = map[key]
                        .Where(y => x != y && y >= ymin && y <= ymax)
                        .Select(y => x + y)
                        .Where(t => !seen.Contains(t));

                    foreach (var t in ts) {
                        seen.Add(t);
                        count++;
                    }
                }
            }


            Console.WriteLine(count);
        }
    }
}
