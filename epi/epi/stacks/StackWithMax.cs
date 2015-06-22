using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.stacks {
    class StackWithMax {
        private readonly Stack<int> items;
        private readonly Stack<MaxItemInfo> maxes;

        public bool Any { get { return this.items.Any(); } }

        public StackWithMax() {
            this.items = new Stack<int>();
            this.maxes = new Stack<MaxItemInfo>();
        }

        public void Push(int value) {
            this.items.Push(value);

            if (!this.maxes.Any() || value > this.maxes.Peek().Value) {
                this.maxes.Push(new MaxItemInfo(value));
            } else if (this.maxes.Peek().Value == value) {
                this.maxes.Peek().Increment();
            }
        }

        public int Pop() {
            var value = this.items.Pop();

            var max = this.maxes.Peek();
            if (max.Value == value) {
                max.Decrement();
                if (max.Empty) {
                    this.maxes.Pop();
                }
            }

            return value;
        }

        public int Max() {
            return this.maxes.Peek().Value;
        }

        class MaxItemInfo {
            public int Value { get; private set; }
            public int Count { get; private set; }
            public bool Empty { get { return this.Count == 0; } }


            public MaxItemInfo(int value) {
                this.Value = value;
                this.Count = 1;
            }

            public void Increment() {
                this.Count++;
            }

            public void Decrement() {
                this.Count--;
            }
        }
    }
}
