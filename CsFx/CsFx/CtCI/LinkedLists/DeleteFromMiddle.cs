using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.LinkedLists {
    class DeleteFromMiddle {
        public static void Delete(LinkedListNode node) {
            if (node == null) {
                throw new ArgumentNullException("node");
            } else if (node.Next == null) {
                throw new ArgumentException("interior node required");
            }

            node.Value = node.Next.Value;
            node.Next = node.Next.Next;
        }
    }
}
