using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.TreesAndGraphs {
    class BinaryTreeFromSortedArray {
        public static BinaryTreeNode ToBinaryTree(int[] array) {
            if (array == null) {
                throw new ArgumentNullException("array");
            }

            var last = Int32.MinValue;
            foreach (var current in array) {
                if (last > current) {
                    throw new ArgumentException();
                }

                last = current;
            }

            return ToBinaryTree(array, 0, array.Length - 1);
        }

        public static BinaryTreeNode ToBinaryTree(
            int[] array,
            int startIndex,
            int endIndex) {

            if (startIndex > endIndex) {
                return null;
            }

            var middleIndex = startIndex + ((endIndex - startIndex) / 2);
            return new BinaryTreeNode {
                Value = array[middleIndex],
                Left = ToBinaryTree(array, startIndex, middleIndex - 1),
                Right = ToBinaryTree(array, middleIndex + 1, endIndex)
            };
        }

    }
}
