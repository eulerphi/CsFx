using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.common {
    class LinkedListNode {
        public int Value { get; set; }
        public LinkedListNode Next { get; set; }

        public override string ToString() {
            var list = new List<int>();
            var cur = this;
            while (cur != null) {
                list.Add(cur.Value);
                cur = cur.Next;
            }

            return string.Join(",", list);
        }
    }
}
