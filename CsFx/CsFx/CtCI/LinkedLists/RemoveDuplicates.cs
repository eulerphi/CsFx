using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.LinkedLists {
    class RemoveDuplicates {
        public static void RemoveWithBuffer(LinkedListNode head) {
            var seen = new HashSet<int>();

            var previous = (LinkedListNode)null;
            var current = head;

            while (current != null) {
                if (seen.Contains(current.Value)) {
                    previous.Next = current.Next;
                } else {
                    seen.Add(current.Value);
                    previous = current;
                }

                current = current.Next;
            }
        }

        public static void RemoveWithoutBuffer(LinkedListNode head) {
            var current = head;

            while (current != null) {
                var runner = current;
                while (runner.Next != null) {
                    if (current.Value == runner.Next.Value) {
                        runner.Next = runner.Next.Next;
                    } else {
                        runner = runner.Next;
                    }
                }

                current = current.Next;
            }
        }
    }
}
