using epi.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.lists {
    class TestOverlapping {
        public static void Run() {
            var last = new LinkedListNode {
                Value = 34
            };
            var shared = new LinkedListNode {
                Value = 30,
                Next = new LinkedListNode {
                    Value = 31,
                    Next = new LinkedListNode {
                        Value = 32,
                        Next = new LinkedListNode {
                            Value = 33,
                            Next = last
                        }
                    }
                }
            };

            var l1 = new LinkedListNode {
                Value = 10,
                Next = new LinkedListNode {
                    Value = 11,
                    Next = new LinkedListNode {
                        Value = 12,
                        Next = shared
                    }
                }
            };
            var l2 = new LinkedListNode {
                Value = 20,
                Next = new LinkedListNode {
                    Value = 21,
                    Next = l1.Next
                }
            };

            last.Next = shared;
            var result = Test(l1, l2);
        }

        private static LinkedListNode Test(LinkedListNode a, LinkedListNode b) {
            var aCycleHead = CycleHeadOrDefault(a);
            var bCycleHead = CycleHeadOrDefault(b);

            var bothAcyclic = aCycleHead == null && bCycleHead == null;
            if (bothAcyclic) {
                return TestAcyclic(a, b, null);
            }

            var bothCyclic = aCycleHead != null && bCycleHead != null;
            if (!bothCyclic) {
                return null;
            }

            var current = aCycleHead;
            do {
                current = current.Next;
            } while (current != aCycleHead && current != bCycleHead);

            var sameCycle = current == bCycleHead;
            if (!sameCycle) {
                return null;
            }

            var overlapBeforeCycle = aCycleHead == bCycleHead;
            return overlapBeforeCycle
                ? TestAcyclic(a, b, aCycleHead.Next)
                : aCycleHead;
        }

        private static LinkedListNode CycleHeadOrDefault(LinkedListNode head) {
            var fast = head;
            var slow = head;

            while (fast != null && fast.Next != null) {
                fast = fast.Next.Next;
                slow = slow.Next;

                if (fast == slow) {
                    break;
                }
            }

            if (fast == null || fast.Next == null) {
                return null;
            }

            var cycleLength = 0;
            do {
                cycleLength++;
                slow = slow.Next;
            } while (slow != fast);

            fast = head;
            for (var i = 0; i < cycleLength; i++) {
                fast = fast.Next;
            }

            slow = head;
            while (fast != slow) {
                fast = fast.Next;
                slow = slow.Next;
            }

            return fast;
        }

        private static LinkedListNode TestAcyclic(LinkedListNode a, LinkedListNode b, LinkedListNode nullequv) {
            var aLen = 0;
            var bLen = 0;

            var aCur = a;
            var bCur = b;
            while (aCur.Next != nullequv || bCur.Next != nullequv) {
                if (aCur.Next != nullequv) {
                    aLen++;
                    aCur = aCur.Next;
                }

                if (bCur.Next != nullequv) {
                    bLen++;
                    bCur = bCur.Next;
                }
            }

            if (aCur != bCur) {
                return null;
            }

            aCur = a;
            bCur = b;
            var diffLen = Math.Abs(aLen - bLen);
            for (var i = 0; i < diffLen; i++) {
                if (aLen > bLen) {
                    aCur = aCur.Next;
                } else {
                    bCur = bCur.Next;
                }
            }

            while (aCur != bCur) {
                aCur = aCur.Next;
                bCur = bCur.Next;
            }

            return aCur;
        }
    }
}
