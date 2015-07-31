using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ada1 {
    class MinCut {
        public static void Run() {
            //var lines = new string[] {
            //    "1 2 4",
            //    "2 1 4 3",
            //    "3 2 4",
            //    "4 1 2 3"
            //};
            var lines = File.ReadAllLines(@"P3.txt");

            var results = new List<int>();
            //var master = new Random();
            var rand = new Random();

            for (var i = 0; i < 100; i++) {
                var nodes = lines.Select(GraphNode.Parse).ToArray();
                var map = nodes.ToDictionary(n => n.Id);
                var foo = nodes.SelectMany(n => n.EdgesTo).Where(kvp => kvp.Value > 1).ToList();

                //var rand = new Random(master.Next());
                var edges = GetEdges(map);
                while (map.Count > 2) {
                    var edgeIndex = rand.Next(0, edges.Count);
                    var edgeToRemove = edges[edgeIndex];
                    //var first = rand.NextDouble() > 0.5;
                    var first = true;
                    var node = first
                        ? map[edges[edgeIndex].Item1]
                        : map[edges[edgeIndex].Item2];
                    var other = first
                        ? map[edges[edgeIndex].Item2]
                        : map[edges[edgeIndex].Item1];
                    node.Contract(other, map);

                    edges = GetEdges(map);
                }

                var edgeCount = map[edges.First().Item1].EdgesTo.First().Value;
                results.Add(edgeCount);
            }

            results.Sort();
            var min = results.First();
            Console.Read();
        }

        private static IList<Tuple<int, int>> GetEdges(Dictionary<int, GraphNode> nodes) {
            return nodes.SelectMany(n => n.Value.GetEdges()).ToList();
        }
    }

    class GraphNode {
        public int Id { get; private set; }
        public Dictionary<int, int> EdgesTo { get; private set; }

        public GraphNode(int id, int[] edgesTo) {
            this.Id = id;
            this.EdgesTo = new Dictionary<int, int>();
            foreach (var head in edgesTo) {
                if (!this.EdgesTo.ContainsKey(head)) {
                    this.EdgesTo[head] = 0;
                }

                this.EdgesTo[head]++;
            }
        }

        public IEnumerable<Tuple<int, int>> GetEdges() {
            //foreach (var kvp in this.EdgesTo) {
            //    var head = kvp.Key;
            //    var min = Math.Min(head, this.Id);
            //    var max = Math.Max(head, this.Id);
            //    yield return Tuple.Create(min, max);
            //}

            var edges = new List<Tuple<int, int>>();
            foreach (var kvp in this.EdgesTo) {
                for (var i = 0; i < kvp.Value; i++) {
                    edges.Add(Tuple.Create(this.Id, kvp.Key));
                }
            }
            return edges;
        }

        public void Contract(GraphNode other, Dictionary<int, GraphNode> map) {
            foreach (var kvp in other.EdgesTo) {
                var head = kvp.Key;
                if (head == this.Id) continue;

                map[head].ReplaceEdge(other.Id, this.Id);

                if (!this.EdgesTo.ContainsKey(head)) {
                    this.EdgesTo[head] = 0;
                }
                this.EdgesTo[head] = map[head].EdgesTo[this.Id];
            }

            this.EdgesTo.Remove(other.Id);
            map.Remove(other.Id);
        }

        public void ReplaceEdge(int oldId, int newId) {
            if (!this.EdgesTo.ContainsKey(newId)) {
                this.EdgesTo[newId] = 0;
            }

            this.EdgesTo[newId] += this.EdgesTo[oldId];
            this.EdgesTo.Remove(oldId);
        }

        public static GraphNode Parse(string line) {
            var parts = line.Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse);
            return new GraphNode(parts.First(), parts.Skip(1).ToArray());
        }
    }
}
