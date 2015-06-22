using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.LinkedLists {
    class ForwardAddition {
        public static LinkedListNode Add(LinkedListNode a, LinkedListNode b) {
            if (a == null) {
                return b;
            } else if (b == null) {
                return a;
            }

            var aLength = GetLength(a);
            var bLength = GetLength(b);

            a = PadList(a, bLength - aLength);
            b = PadList(b, aLength - bLength);

            var sum = AddInternal(a, b);

            return sum.Carry > 0
                ? new LinkedListNode { Value = sum.Carry, Next = sum.Node }
                : sum.Node;
        }

        private static PartialSum AddInternal(
            LinkedListNode a, LinkedListNode b) {

            if (a == null || b == null) {
                return new PartialSum();
            }

            var nextSum = AddInternal(a.Next, b.Next);

            var total = a.Value + b.Value + nextSum.Carry;

            return new PartialSum {
                Carry = total / 10,
                Node = new LinkedListNode {
                    Value = total % 10,
                    Next = nextSum.Node
                }
            };
        }

        private static LinkedListNode PadList(
            LinkedListNode head, int amountToPad) {

            if (amountToPad <= 0) {
                return head;
            }

            var newHead = new LinkedListNode {
                Value = 0,
                Next = head
            };

            return PadList(newHead, amountToPad - 1);
        }

        private static int GetLength(LinkedListNode node) {
            var length = 0;
            while (node != null) {
                length++;
                node = node.Next;
            }

            return length;
        }

        class PartialSum {
            public int Carry { get; set; }
            public LinkedListNode Node { get; set; }
        }
    }
}
