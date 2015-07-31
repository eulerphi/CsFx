using epi.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.lists {
    class Zipping {
        public static void Run() {
            var l1 = new LinkedListNode {
                Value = 10,
                Next = new LinkedListNode {
                    Value = 11,
                    Next = new LinkedListNode {
                        Value = 12,
                        Next = new LinkedListNode {
                            Value = 13,
                            Next = new LinkedListNode {
                                Value = 14
                            }
                        }
                    }
                }
            };

            Zip(l1);
        }

        private static void Zip(LinkedListNode head) {
            var mid = Mid(head);
            mid.Next = Reverse(mid.Next);
            var current = head;
            while (mid.Next != null && current != mid) {
                var next = current.Next;
                current.Next = mid.Next;
                mid.Next = mid.Next.Next;
                current.Next.Next = next;
                current = next;
            }
        }

        private static LinkedListNode Mid(LinkedListNode head) {
            var fast = head;
            var slow = head;

            while (fast.Next != null && fast.Next.Next != null) {
                fast = fast.Next.Next;
                slow = slow.Next;
            }

            return slow;
        }

        private static LinkedListNode Reverse(LinkedListNode head) {
            LinkedListNode prev = null;
            var cur = head;

            while (cur != null) {
                var next = cur.Next;
                cur.Next = prev;
                prev = cur;
                cur = next;
            }

            return prev;
        }
    }
}
