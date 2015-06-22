using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.StacksAndQueues {
    class TowerOfHanoi {
        public static void Solve(
            Stack<int> source,
            Stack<int> destination,
            Stack<int> buffer) {

            if (source == null) {
                throw new ArgumentNullException("source");
            } else if (destination == null) {
                throw new ArgumentNullException("destination");
            } else if (buffer == null) {
                throw new ArgumentNullException("buffer");
            } else if (destination.Any()) {
                throw new ArgumentException("destination");
            } else if (buffer.Any()) {
                throw new ArgumentException("buffer");
            }

            var current = Int32.MinValue;
            foreach (var value in source) {
                if (current > value) {
                    throw new ArgumentException("source");
                }

                current = value;
            }

            MoveDisks(source.Count, source, destination, buffer);
        }

        private static void MoveDisks(
            int n,
            Stack<int> source,
            Stack<int> destination,
            Stack<int> buffer) {

            if (n <= 0) {
                return;
            }

            MoveDisks(
                n - 1,
                source: source,
                destination: buffer,
                buffer: destination);

            destination.Push(source.Pop());

            MoveDisks(
                n - 1,
                source: buffer,
                destination: destination,
                buffer: source);
        }
    }
}
