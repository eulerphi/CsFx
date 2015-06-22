using CsFx.CtCI.Shared;
using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.RecursionAndDynamicProgramming {
    class CountWaysFromTopLeftToBottomRight {
        public static int Count(int x, int y) {
            if (x < 0 || y < 0) {
                return 0;
            }

            var numerator = SpecialFunctions.Factorial(x + y);
            var denominator = SpecialFunctions.Factorial(x)
                            * SpecialFunctions.Factorial(y);

            return (int)(numerator / denominator);
        }

        public static int Count(int x, int y, Func<int, int, bool> isFree) {
            if (isFree == null) {
                throw new ArgumentNullException("isFree");
            }

            if (x < 0 || y < 0 || !isFree(x, y)) {
                return 0;
            } else if (x == 0 && y == 0) {
                return 1;
            } else {
                return Count(x - 1, y, isFree) + Count(x, y - 1, isFree);
            }
        }

        public static bool FindPath(
            int x,
            int y,
            Func<int, int, bool> isFree,
            out Point[] path) {

            path = null;

            if (isFree == null) {
                throw new ArgumentNullException("isFree");
            }

            var cache = new Dictionary<Point, bool>();
            var aPath = new List<Point>();
            var success = FindPath(x, y, isFree, cache, aPath);
            path = aPath.ToArray();
            return success;
        }

        private static bool FindPath(
            int x,
            int y,
            Func<int, int, bool> isFree,
            Dictionary<Point, bool> cache,
            List<Point> path) {

            var p = new Point(x, y);
            if (cache.ContainsKey(p)) {
                return cache[p];
            }

            path.Add(p);
            if (x == 0 && y == 0) {
                return true;
            }

            var success = false;
            if (x >= 1 && isFree(x - 1, y)) {
                success = FindPath(x - 1, y, isFree, cache, path);
            }

            if (!success && y >= 1 && isFree(x, y - 1)) {
                success = FindPath(x, y - 1, isFree, cache, path);
            }

            if (!success) {
                path.Remove(p);
            }

            cache.Add(p, success);
            return success;
        }
    }
}
