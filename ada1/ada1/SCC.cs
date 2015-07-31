using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ada1 {
    class SCC {
        public static void Run() {
            var input = File.ReadLines(@"SCC.txt");
            var g = Graph.Parse(input);
            var ordered = Order(g);
            var scc = Get(g, ordered).OrderByDescending(c => c.Count).Take(10).ToList();
            for (var i = 0; i < scc.Count; i++) {
                var c = scc[i];
                Console.WriteLine(String.Format("{0}: {1}", i + 1, c.Count));
            }
            Console.Read();
        }

        private static IList<List<int>> Get(Graph g, Stack<int> ordered) {
            var visited = new HashSet<int>();
            var queue = new Queue<int>();
            var result = new List<List<int>>();

            foreach (var node in ordered) {
                if (visited.Contains(node)) continue;

                var component = new List<int>();

                queue.Enqueue(node);
                visited.Add(node);
                while (queue.Any()) {
                    var u = queue.Dequeue();

                    component.Add(u);

                    foreach (var v in g.From(u)) {
                        if (visited.Contains(v)) continue;

                        visited.Add(v);
                        queue.Enqueue(v);
                    }
                }

                result.Add(component);
            }

            return result;
        }

        private static Stack<int> Order(Graph g) {
            var visited = new HashSet<int>();
            var stack = new Stack<Tuple<int, int>>();
            var result = new Stack<int>();

            foreach (var node in g.Nodes()) {
                if (visited.Contains(node)) continue;

                stack.Push(Tuple.Create(node, 0));
                visited.Add(node);
                while (stack.Any()) {
                    var pair = stack.Pop();
                    var u = pair.Item1;
                    var i = pair.Item2;

                    var vs = g.To(u);
                    if (vs.Count == i) {
                        result.Push(u);
                    } else {
                        stack.Push(Tuple.Create(u, i + 1));
                        var v = vs[i];
                        if (!visited.Contains(v)) {
                            visited.Add(v);
                            stack.Push(Tuple.Create(v, 0));
                        }
                    }
                }
            }

            return result;
        }
    }

    class Graph {
        private IDictionary<int, IList<int>> edges;
        private IDictionary<int, IList<int>> reversedEdges;

        public Graph(IDictionary<int, IList<int>> edges, IDictionary<int, IList<int>> reversedEdges) {
            this.edges = edges;
            this.reversedEdges = reversedEdges;
        }

        public IEnumerable<int> Nodes() {
            return this.edges.Keys;
        }

        public IList<int> From(int v) {
            return this.edges[v];
        }

        public IList<int> To(int v) {
            return this.reversedEdges[v];
        }

        public static Graph Parse(IEnumerable<string> unparsedEdges) {
            var edges = new Dictionary<int, IList<int>>();
            var reversedEdges = new Dictionary<int, IList<int>>();

            foreach (var e in unparsedEdges) {
                var pair = e.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                var from = int.Parse(pair[0]);
                var to = int.Parse(pair[1]);

                InitializeKey(edges, from);
                InitializeKey(edges, to);
                edges[from].Add(to);

                InitializeKey(reversedEdges, from);
                InitializeKey(reversedEdges, to);
                reversedEdges[to].Add(from);
            }

            return new Graph(edges, reversedEdges);
        }

        private static void InitializeKey(IDictionary<int, IList<int>> map, int key) {
            if (!map.ContainsKey(key)) map[key] = new List<int>();
        }
    }
}
