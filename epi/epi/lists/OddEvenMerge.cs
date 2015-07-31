using epi.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.lists {
    class OddEvenMerge {
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

            Merge(l1);
        }

        private static void Merge(LinkedListNode head) {
            if (head == null) return;

            var oddHead = new LinkedListNode();
            var oddTail = oddHead;

            var current = head;
            while (current.Next != null) {
                oddTail.Next = current.Next;
                oddTail = oddTail.Next;


                current.Next = current.Next.Next;
                if (current.Next != null) {
                    current = current.Next;
                }
            }

            current.Next = oddHead.Next;
            oddTail.Next = null;
        }
    }
}
