using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.StacksAndQueues {
    class QueueWithTwoStacks {
        private readonly Stack<int> popStack;
        private readonly Stack<int> pushStack;

        public int Count { get { return this.popStack.Count + this.pushStack.Count; } }

        public QueueWithTwoStacks() {
            this.popStack = new Stack<int>();
            this.pushStack = new Stack<int>();
        }

        public void Enqueue(int value) {
            this.pushStack.Push(value);
        }

        public int Dequeue() {
            if (this.Count == 0) {
                throw new InvalidOperationException();
            }

            if (!this.popStack.Any()) {
                while (this.pushStack.Any()) {
                    this.popStack.Push(this.pushStack.Pop());
                }
            }

            return this.popStack.Pop();
        }
    }
}
