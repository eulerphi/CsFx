using epi.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.lists {
    class ReverseSublist {
        public static LinkedListNode Reverse(LinkedListNode a, int lo, int hi) {
            var head = new LinkedListNode { Next = a };

            var before = head;
            for (var i = 0; i < lo - 1; i++) {
                before = before.Next;
            }

            var after = before;
            for (var i = lo - 1; i < hi + 1; i++) {
                after = after.Next;
            }

            var previous = after;
            var current = before.Next;
            var count = hi - lo + 1;
            while (count > 0) {
                var next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
                count--;
            }

            before.Next = previous;

            return head.Next;
        }
    }
}
