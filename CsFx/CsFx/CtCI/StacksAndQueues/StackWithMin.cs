using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.StacksAndQueues {
    class StackWithMin {
        private Stack<int> values;
        private Stack<int> minValues;

        public StackWithMin() {
            this.minValues = new Stack<int>();
            this.values = new Stack<int>();
        }

        public void Push(int value) {
            if (this.values.Count == 0 || value <= this.Min()) {
                this.minValues.Push(value);
            }

            this.values.Push(value);
        }

        public int Pop() {
            var value = this.values.Pop();

            if (value == this.Min()) {
                this.minValues.Pop();
            }

            return value;
        }

        public int Min() {
            return this.minValues.Peek();
        }
    }
}
