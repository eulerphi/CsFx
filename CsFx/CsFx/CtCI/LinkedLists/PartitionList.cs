using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.LinkedLists {
    class PartitionList {
        public static LinkedListNode Partition(LinkedListNode node, int value) {
            LinkedListNode beforeStart = null;
            LinkedListNode beforeEnd = null;
            LinkedListNode afterStart = null;
            LinkedListNode afterEnd = null;

            while (node != null) {
                var next = node.Next;

                // !! IMPORTANT !!
                node.Next = null;

                if (node.Value < value) {
                    if (beforeStart == null) {
                        beforeStart = node;
                        beforeEnd = node;
                    } else {
                        beforeEnd.Next = node;
                        beforeEnd = node;
                    }
                } else {
                    if (afterStart == null) {
                        afterStart = node;
                        afterEnd = node;
                    } else {
                        afterEnd.Next = node;
                        afterEnd = node;
                    }
                }

                node = next;
            }

            if (beforeStart != null) {
                beforeEnd.Next = afterStart;
            }

            return beforeStart != null
                ? beforeStart
                : afterStart;
        }
    }
}
