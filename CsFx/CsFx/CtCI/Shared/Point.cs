using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.Shared {
    class Point : Tuple<int, int> {
        public int X { get { return this.Item1; } }
        public int Y { get { return this.Item2; } }

        public Point(int x, int y) : base(x, y) {
            // empty
        }

        public Point Left() { return new Point(this.X - 1, this.Y); }
        public Point Up() { return new Point(this.X, this.Y + 1); }
        public Point Right() { return new Point(this.X + 1, this.Y); }
        public Point Down() { return new Point(this.X, this.Y - 1); }

        public IEnumerable<Point> Adjacent() {
            yield return this.Left();
            yield return this.Up();
            yield return this.Right();
            yield return this.Down();
        }
    }
}
