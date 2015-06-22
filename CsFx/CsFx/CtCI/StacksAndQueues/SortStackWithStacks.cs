using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.StacksAndQueues {
    class SortStackWithStacks {
        public static void Sort(Stack<int> stack) {
            if (stack == null) {
                throw new ArgumentNullException("stack");
            }

            var sorted = new Stack<int>();

            while (stack.Any()) {
                var value = stack.Pop();
                while (sorted.Any() && sorted.Peek() < value) {
                    stack.Push(sorted.Pop());
                }

                sorted.Push(value);
            }


            while (sorted.Any()) {
                stack.Push(sorted.Pop());
            }
        }
    }
}
