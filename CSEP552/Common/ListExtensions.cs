using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    public static class ListExtensions {
        private static Random random = new Random();

        public static T SelectRandom<T>(this IList<T> list) {
            var index = random.Next(list.Count);
            return list[index];
        }
    }
}
