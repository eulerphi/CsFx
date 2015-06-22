using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.StacksAndQueues {
    class SetOfStacksWithPopAt {
        private int stackLimit;
        private IList<Stack<int>> stacks;
        private Stack<int> CurrentStack { get { return this.stacks.Last(); } }

        public int Count { get { return this.stacks.Count; } }

        public SetOfStacksWithPopAt(int stackLimit) {
            if (stackLimit < 1) {
                throw new ArgumentException("stackLimit");
            }

            this.stackLimit = stackLimit;
            this.stacks = new List<Stack<int>>();
        }

        public void Push(int value) {
            if (!this.stacks.Any() || this.CurrentStack.Count == stackLimit) {
                this.stacks.Add(new Stack<int>());
            }

            this.CurrentStack.Push(value);
        }

        public int Pop() {
            return this.PopAt(this.Count - 1);
        }

        public int PopAt(int stackIndex) {
            if (stackIndex >= this.Count) {
                throw new ArgumentException("stackIndex");
            }

            var result = this.PopAtInternal(stackIndex);

            if (!this.CurrentStack.Any()) {
                this.stacks.Remove(this.CurrentStack);
            }

            Debug.Assert(this.stacks.All(s => s.Any()));

            return result;
        }

        private int PopAtInternal(int stackIndex) {
            var result = this.stacks[stackIndex].Pop();

            var nextStackIndex = stackIndex + 1;
            if (nextStackIndex < this.Count) {
                this.stacks[stackIndex].Push(
                    this.PopAtInternal(nextStackIndex));
            }

            return result;
        }

        internal int[] GetStacksInfo() {
            return this.stacks
                       .Select(s => s.Count)
                       .ToArray();
        }
    }
}
