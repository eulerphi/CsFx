using epi.stacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.queues {
    class QueueWithMax {
        private readonly StackWithMax outStack;
        private readonly StackWithMax inStack;

        public bool Any { get { return this.outStack.Any || this.inStack.Any; } }

        public QueueWithMax() {
            this.outStack = new StackWithMax();
            this.inStack = new StackWithMax();
        }

        public void Enqueue(int value) {
            this.inStack.Push(value);
        }

        public int Dequeue() {
            this.PrepareOutStack();
            return this.outStack.Pop();
        }

        public int Max() {
            this.PrepareOutStack();
            return this.outStack.Max();
        }

        private void PrepareOutStack() {
            if (!this.outStack.Any && !this.inStack.Any) {
                throw new InvalidOperationException();
            }

            if (!this.outStack.Any && this.inStack.Any) {
                while (this.inStack.Any) {
                    this.outStack.Push(this.inStack.Pop());
                }
            }
        }


    }
}
