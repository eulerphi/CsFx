using epi.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.lists {
    class ReverseList {
        public static LinkedListNode Reverse(LinkedListNode a) {
            if (a == null) {
                return null;
            }

            LinkedListNode previous = null;
            var current = a;

            while (current != null) {
                var temp = current.Next;
                current.Next = previous;
                previous = current;
                current = temp;
            }

            return previous;
        }
    }
}
