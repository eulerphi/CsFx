using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.StacksAndQueues {
    class SetOfStacks {
        private int stackLimit;
        private Stack<Stack<int>> stacks;
        private Stack<int> CurrentStack { get { return this.stacks.Peek(); } }

        public SetOfStacks(int stackLimit) {
            if (stackLimit < 1) {
                throw new ArgumentException("stackLimit");
            }

            this.stackLimit = stackLimit;
            this.stacks = new Stack<Stack<int>>();
        }

        public void Push(int value) {
            if (!this.stacks.Any() || this.CurrentStack.Count == stackLimit) {
                this.stacks.Push(new Stack<int>());
            }

            this.CurrentStack.Push(value);

        }

        public int Pop() {
            var result = this.CurrentStack.Pop();

            if (!this.CurrentStack.Any()) {
                this.stacks.Pop();
            }

            return result;
        }

        internal int[] GetStacksInfo() {
            return this.stacks
                       .Select(s => s.Count)
                       .Reverse()
                       .ToArray();
        }
    }
}
