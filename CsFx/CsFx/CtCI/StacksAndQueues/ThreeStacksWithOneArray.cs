using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.StacksAndQueues {
    class ThreeStacksWithOneArray {
        public class Stack {
            private int[] array;
            private int startIndex;
            private int endIndex;
            private int capacity;
            private int count;

            public Stack(int[] array, int startIndex, int endIndex) {
                this.array = array;
                this.startIndex = startIndex;
                this.endIndex = endIndex;
                this.count = 0;
                this.capacity = endIndex - startIndex;
            }

            public void Push(int value) {
                Debug.Assert(this.capacity >= this.count);

                if (this.count == this.capacity) {
                    this.Grow();
                }

                this.array[this.startIndex + this.count] = value;
                this.count++;
            }

            public int Pop() {
                var value = this.Peek();
                this.count--;
                return value;
            }

            public int Peek() {
                return this.array[this.startIndex + this.count - 1];
            }

            private void Grow() {
                throw new NotImplementedException();
            }
        }

        public class MemoryManager {
            
        }
    }
}
