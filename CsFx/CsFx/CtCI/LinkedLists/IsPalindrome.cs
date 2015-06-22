using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.LinkedLists {
    class IsPalindrome {
        public static bool Check(LinkedListNode node) {
            var length = 0;
            var current = node;
            while (current != null) {
                length++;
                current = current.Next;
            }

            return Check(node, length).IsPalindrome;
        }

        private static Result Check(LinkedListNode node, int length) {
            if (node == null || length == 0) {
                return new Result {
                    IsPalindrome = true
                };
            } else if (length == 1) {
                return new Result {
                    IsPalindrome = true,
                    Node = node.Next
                };
            } else if (length == 2) {
                return new Result {
                    IsPalindrome = node.Value == node.Next.Value,
                    Node = node.Next.Next
                };
            }

            var result = Check(node.Next, length - 2);
            if (result.IsPalindrome && result.Node != null) {
                result.IsPalindrome = node.Value == result.Node.Value;
                result.Node = result.Node.Next;
            }

            return result;
        }

        class Result {
            public bool IsPalindrome { get; set; }
            public LinkedListNode Node { get; set; }
        }
    }
}
