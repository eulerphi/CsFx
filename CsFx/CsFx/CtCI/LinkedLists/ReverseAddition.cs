using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.LinkedLists {
    class ReverseAddition {
        public static LinkedListNode Add(
            LinkedListNode a,
            LinkedListNode b) {

            return Add(a, b, 0);
        }


        private static LinkedListNode Add(
            LinkedListNode a,
            LinkedListNode b,
            int carry) {

            if (a == null && b == null && carry == 0) {
                return null;
            }

            var total = carry;
            total += a != null ? a.Value : 0;
            total += b != null ? b.Value : 0;

            var value = total % 10;
            var newCarry = total / 10;

            var result = new LinkedListNode { Value = value };

            if (a != null || b != null || newCarry > 0) {
                result.Next = Add(
                    a != null ? a.Next : null,
                    b != null ? b.Next : null,
                    newCarry);
            }

            return result;
        }
    }
}
