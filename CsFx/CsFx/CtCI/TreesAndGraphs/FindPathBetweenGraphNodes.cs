using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.TreesAndGraphs {
    class FindPathBetweenGraphNodes {
        public static bool FindBFS(GraphNode a, GraphNode b) {
            if (a == null) {
                throw new ArgumentNullException("a");
            } else if (b == null) {
                throw new ArgumentNullException("b");
            }

            var seen = new HashSet<GraphNode>();
            var toSearch = new Queue<GraphNode>();

            toSearch.Enqueue(a);

            while (toSearch.Any()) {
                var node = toSearch.Dequeue();
                if (seen.Contains(node)) {
                    continue;
                }

                seen.Add(node);

                if (node == b) {
                    return true;
                } else {
                    foreach (var adjacent in node.AdjacentNodes) {
                        toSearch.Enqueue(adjacent);
                    }
                }
            }

            return false;
        }

        public static bool FindDFS(GraphNode a, GraphNode b) {
            if (a == null) {
                throw new ArgumentNullException("a");
            } else if (b == null) {
                throw new ArgumentNullException("b");
            }

            var seen = new HashSet<GraphNode>();
            return FindDFSInternal(a, b, seen);
        }

        private static bool FindDFSInternal(GraphNode a, GraphNode b, HashSet<GraphNode> seen) {
            if (a == b) {
                return true;
            }

            foreach (var adjacent in a.AdjacentNodes) {
                if (seen.Contains(adjacent)) {
                    continue;
                }

                seen.Add(adjacent);
                if (FindDFSInternal(adjacent, b, seen)) {
                    return true;
                }
            }

            return false;
        }
    }
}
