using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.Shared {
    public class Pair : Tuple<int, int> {
        public int Fst { get { return this.Item1; } }
        public int Snd { get { return this.Item2; } }

        public Pair(int fst, int snd)
            : base(fst, snd) {
            // empty
        }

        public bool IsLessThan(Pair other) {
            if (other == null) {
                throw new ArgumentNullException();
            }

            return other.Fst > this.Fst
                && other.Snd > this.Snd;
        }
    }
}
