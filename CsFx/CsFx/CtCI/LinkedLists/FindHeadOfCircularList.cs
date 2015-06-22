using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.LinkedLists {
    class FindHeadOfCircularList {
        public static LinkedListNode Find(LinkedListNode node) {
            LinkedListNode fast = node;
            LinkedListNode slow = node;

            while (fast != null && fast.Next != null) {
                slow = slow.Next;
                fast = fast.Next.Next;
                if (slow == fast) {
                    break;
                }
            }

            if (fast == null || fast.Next == null) {
                return null;
            }

            slow = node;
            while (slow != fast) {
                slow = slow.Next;
                fast = fast.Next;
            }

            return fast;
        }
    }
}
