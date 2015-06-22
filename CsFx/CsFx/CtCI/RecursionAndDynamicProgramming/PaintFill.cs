using CsFx.CtCI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.RecursionAndDynamicProgramming {
    class PaintFill {
        public static void FillRecursive(int[][] screen, Point point, int to) {
            if (!InBounds(screen, point)) {
                throw new ArgumentException();
            }

            var from = screen[point.Y][point.X];
            Fill(screen, point, from, to);
        }

        private static void Fill(int[][] screen, Point point, int from, int to) {
            if (!InBounds(screen, point)) {
                return;
            }

            if (screen[point.Y][point.X] != from) {
                return;
            }

            screen[point.Y][point.X] = to;

            Fill(screen, point.Left(), from, to);
            Fill(screen, point.Up(), from, to);
            Fill(screen, point.Right(), from, to);
            Fill(screen, point.Down(), from, to);
        }

        public static void FillIterative(int[][] screen, Point point, int to) {
            if (!InBounds(screen, point)) {
                throw new ArgumentException();
            }

            var from = screen[point.Y][point.X];
            var queue = new Queue<Point>();
            queue.Enqueue(point);

            while (queue.Any()) {
                var p = queue.Dequeue();

                screen[p.Y][p.X] = to;

                foreach (var adjacent in p.Adjacent()) {
                    if (ShouldFill(screen, adjacent, from)) {
                        queue.Enqueue(adjacent);
                    }
                }
            }
        }

        private static bool ShouldFill(int[][] screen, Point p, int from) {
            return InBounds(screen, p)
                && screen[p.Y][p.X] == from;
        }

        private static bool InBounds(int[][] screen, Point p) {
            return p.Y >= 0 && p.Y < screen.Length
                && p.X >= 0 && p.X < screen[p.Y].Length;
        }
    }
}
