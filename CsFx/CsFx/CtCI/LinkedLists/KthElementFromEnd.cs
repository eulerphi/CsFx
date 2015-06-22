using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.LinkedLists {
    class KthElementFromEnd {
        public static LinkedListNode Find(LinkedListNode head, int k) {
            var fast = head;
            var slow = head;

            var i = 0;
            for (; i < k && fast != null; i++) {
                fast = fast.Next;
            }

            if (i != k) {
                return null;
            }

            while (fast.Next != null) {
                fast = fast.Next;
                slow = slow.Next;
            }

            return slow;
        }
    }
}
