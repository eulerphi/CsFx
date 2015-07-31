using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ada2 {
    class PrimMST {
        public static void Run() {
            var edges = File
                .ReadAllLines("P1_edges.txt")
                .Skip(1)
                .Select(Edge.Parse);
            var g = new Graph(edges);

            var mst = new HashSet<int>();
            var heap = new MinHeap();

            var mstCost = 0;
            while (mst.Count < g.Vertices().Count) {
                var next = mst.Any()
                    ? heap.Extract()
                    : Vertex.ArbitraryStart(g);

                mst.Add(next.Id);
                mstCost += next.Weight;

                foreach (var e in g.From(next.Id)) {
                    if (mst.Contains(e.To)) continue;

                    var v = new Vertex(e.To, e.Weight);
                    if (heap.Contains(e.To)) {
                        var existing = heap.Remove(e.To);
                        v = v.Min(existing);
                    }

                    heap.Insert(v);
                }
            }

            Console.WriteLine(mstCost);
        }

        class Graph {
            private IDictionary<int, IList<Edge>> vertexToEdges;

            public Graph(IEnumerable<Edge> edges) {
                this.vertexToEdges = new Dictionary<int, IList<Edge>>();
                foreach (var e in edges) {
                    if (!this.vertexToEdges.ContainsKey(e.From)) {
                        this.vertexToEdges[e.From] = new List<Edge>();
                    }

                    if (!this.vertexToEdges.ContainsKey(e.To)) {
                        this.vertexToEdges[e.To] = new List<Edge>();
                    }

                    this.vertexToEdges[e.From].Add(e);
                    this.vertexToEdges[e.To].Add(new Edge(e.To, e.From, e.Weight));
                }
            }

            public ICollection<int> Vertices() {
                return this.vertexToEdges.Keys;
            }

            public IList<Edge> From(int id) {
                return this.vertexToEdges.ContainsKey(id)
                    ? this.vertexToEdges[id]
                    : new List<Edge>();
            }
        }
        class Edge {
            public int From { get; private set; }
            public int To { get; private set; }
            public int Weight { get; private set; }

            public Edge(int from, int to, int weight) {
                this.From = from;
                this.To = to;
                this.Weight = weight;
            }

            public static Edge Parse(string input) {
                var parts = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
                return new Edge(parts[0], parts[1], parts[2]);
            }

            public override string ToString() {
                return String.Format("{0}-{1}: {2}", this.From, this.To, this.Weight);
            }
        }

        class Vertex {
            public int Id { get; private set; }
            public int Weight { get; private set; }

            public Vertex(int id, int weight) {
                this.Id = id;
                this.Weight = weight;
            }

            public Vertex Min(Vertex e) {
                return e.Weight >= this.Weight ? this : new Vertex(this.Id, e.Weight);
            }

            public static Vertex ArbitraryStart(Graph g) {
                var v = g.Vertices().Skip(5).First();
                return new Vertex(v, 0);
            }

            public override string ToString() {
                return String.Format("{0}: {1}", this.Id, this.Weight);
            }
        }

        class MinHeap {
            private List<Vertex> items;
            private Dictionary<int, int> idToIndex;

            public MinHeap() {
                this.items = new List<Vertex>();
                this.idToIndex = new Dictionary<int, int>();
            }

            public bool Any() {
                return this.items.Count > 0;
            }

            public bool Contains(int id) {
                return this.idToIndex.ContainsKey(id);
            }

            public void Check() {
                if (!items.Any()) return;

                Check(items.First());
            }

            public void Check(Vertex item) {
                if (item == null) return;

                var left = Left(item);
                var right = Right(item);

                if (left != null && item.Weight > left.Weight) {
                    throw new Exception();
                }

                if (right != null && item.Weight > right.Weight) {
                    throw new Exception();
                }

                Check(left);
                Check(right);
            }

            public void Clear() {
                idToIndex.Clear();
                items.Clear();
            }

            public Vertex Extract() {
                Check();

                var first = this.items.First();
                this.Remove(first.Id);

                Check();

                return first;
            }

            public void Insert(Vertex item) {
                Check();

                items.Add(item);
                idToIndex[item.Id] = items.Count - 1;

                if (this.items.Count > 1) {
                    this.BubbleUp(item);
                }

                Check();
            }

            public Vertex Remove(int id) {
                Check();

                var idx = idToIndex[id];
                var item = items[idx];
                var last = this.items.Last();
                this.Swap(item, last);

                this.items.RemoveAt(items.Count - 1);
                this.idToIndex.Remove(item.Id);

                if (item.Id != last.Id) {
                    this.BubbleUp(last);
                    this.BubbleDown(last);
                }

                Check();

                return item;
            }

            private bool IsLessThan(Vertex x, Vertex y) {
                if (y == null) {
                    return true;
                }

                return x.Weight <= y.Weight;
            }

            private void BubbleDown(Vertex item) {
                if (item == items.Last()) return;

                var left = this.Left(item);
                var right = this.Right(item);

                var lessThanChildren = this.IsLessThan(item, left)
                                    && this.IsLessThan(item, right);
                if (lessThanChildren) {
                    return;
                }

                var smallerChild = IsLessThan(left, right) ? left : right;
                this.Swap(item, smallerChild);

                this.BubbleDown(item);
            }

            private void BubbleUp(Vertex item) {
                if (item == items.First()) return;

                var parent = this.Parent(item);
                if (!this.IsLessThan(item, parent)) {
                    return;
                }

                this.Swap(item, parent);
                this.BubbleUp(item);
            }

            private Vertex Left(Vertex item) {
                var idx = idToIndex[item.Id];
                var leftIdx = 2 * idx + 1;
                return leftIdx < items.Count
                    ? items[leftIdx]
                    : null;
            }

            private Vertex Right(Vertex item) {
                var idx = idToIndex[item.Id];
                var rightIdx = 2 * idx + 2;
                return rightIdx < items.Count
                    ? items[rightIdx]
                    : null;
            }

            private Vertex Parent(Vertex item) {
                var idx = idToIndex[item.Id];
                return items[(idx - 1) / 2];
            }

            private void Swap(Vertex x, Vertex y) {
                var xIdx = this.idToIndex[x.Id];
                var yIdx = this.idToIndex[y.Id];

                items[yIdx] = x;
                idToIndex[x.Id] = yIdx;

                items[xIdx] = y;
                idToIndex[y.Id] = xIdx;
            }
        }
    }
}
