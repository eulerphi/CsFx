using epi.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.lists {
    class MergeLists {
        public static LinkedListNode Merge(LinkedListNode a, LinkedListNode b) {
            var head = new LinkedListNode();
            var current = head;

            while (a != null || b != null) {
                if (a == null) {
                    current.Next = b;
                    b = b.Next;
                } else if (b == null) {
                    current.Next = a;
                    a = a.Next;
                } else if (a.Value > b.Value) {
                    current.Next = b;
                    b = b.Next;
                } else {
                    current.Next = a;
                    a = a.Next;
                }

                current = current.Next;
            }

            head = head.Next;
            return head;
        }
    }
}
