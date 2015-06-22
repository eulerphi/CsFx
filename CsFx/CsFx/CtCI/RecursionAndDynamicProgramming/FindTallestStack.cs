using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.RecursionAndDynamicProgramming {
    class FindTallestStack {
        public static IList<Box> Find(Box[] boxes) {
            return Find(boxes, null, new Dictionary<Box, IList<Box>>());
        }

        private static IList<Box> Find(
            Box[] boxes,
            Box previous,
            Dictionary<Box, IList<Box>> cache) {

            if (previous != null && cache.ContainsKey(previous)) {
                return cache[previous];
            }

            IList<Box> maxStack = null;
            var maxHeight = 0;

            foreach (var next in boxes) {
                if (next.IsSmallerThan(previous)) {
                    var newStack = Find(boxes, next, cache);
                    var newHeight = newStack.Sum(b => b.Height);

                    if (newHeight > maxHeight) {
                        maxHeight = newHeight;
                        maxStack = newStack;
                    }
                }
            }

            maxStack = maxStack != null
                ? new List<Box>(maxStack)
                : new List<Box>();

            if (previous != null) {
                maxStack.Add(previous);
                cache.Add(previous, maxStack);
            }


            return maxStack;
        }
    }

    class Box : Tuple<int, int, int> {
        public int Width { get { return this.Item1; } }
        public int Height { get { return this.Item2; } }
        public int Depth { get { return this.Item3; } }


        public Box(int w, int h, int d)
            : base(w, h, d) {

        }

        internal bool IsSmallerThan(Box other) {
            if (other == null) {
                return true;
            }

            return this.Width < other.Width
                && this.Height < other.Height
                && this.Depth < other.Depth;
        }
    }
}
