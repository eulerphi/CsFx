using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ada2 {
    class APSP {
        public static void Run() {
            var g1 = Graph.Parse(File.ReadAllLines("P4_g1.txt"));

        }

        private static void Dijkstra(Graph g) {

        }

        private static void BellmanFord(Graph g) {

        }

        class MinHeap {
            private IList<Edge> items;
            private IDictionary<Edge, int> edgeToIndex;

            private int LastIndex { get { return items.Count - 1; } }

            public MinHeap() {
                items = new List<Edge>();
            }

            public void Add(Edge e) {
                items.Add(e);
                edgeToIndex[e] = items.Count - 1;
                BubbleUp(e);
            }

            public Edge Delete(Edge e) {
                var last = items.Last();
                Swap(e, last);
                items.RemoveAt(LastIndex);

                if (items.Any()) {
                    BubbleUp(last);
                    BubbleDown(last);
                }

                return e;
            }

            public Edge Extract() {
                return Delete(items.First());
            }

            private void BubbleUp(Edge e) {
                var parent = Parent(e);
                if (IsLessThan(e, parent)) {
                    Swap(e, parent);
                }

                BubbleUp(e);
            }

            private void BubbleDown(Edge e) {
                var left = Left(e);
                var right = Right(e);

                if (IsLessThan(e, left) && IsLessThan(e, right)) {
                    return;
                }

                var smaller = IsLessThan(left, right) ? left : right;
                Swap(e, smaller);

                BubbleDown(e);
            }

            private void Swap(Edge x, Edge y) {
                var xIdx = edgeToIndex[x];
                var yIdx = edgeToIndex[y];

                items[yIdx] = x;
                edgeToIndex[x] = yIdx;

                items[xIdx] = y;
                edgeToIndex[y] = xIdx;
            }

            private bool IsLessThan(Edge x, Edge y) {
                return y != null && x.Cost < y.Cost;
            }

            private Edge Parent(Edge e) {
                var idx = (edgeToIndex[e] - 1) / 2;
                return idx >= 0 ? items[idx] : null;
            }

            private Edge Left(Edge e) {
                var idx = 2 * edgeToIndex[e] + 1;
                return idx <= LastIndex ? items[idx] : null;
            }

            private Edge Right(Edge e) {
                var idx = 2 * edgeToIndex[e] + 2;
                return idx <= LastIndex ? items[idx] : null;
            }
        }

        class Graph {
            private IDictionary<int, List<Edge>> tailToEdge;

            public int VertexCount { get { return tailToEdge.Keys.Count; } }

            public Graph(IList<Edge> edges) {
                tailToEdge = edges
                    .GroupBy(e => e.From)
                    .ToDictionary(g => g.Key, g => g.ToList());
            }

            public static Graph Parse(string[] input) {
                var edges = input
                    .Skip(1)
                    .Select(Edge.Parse)
                    .ToList();

                return new Graph(edges);
            }

            public IEnumerable<Edge> From(int u) {
                return tailToEdge.ContainsKey(u)
                    ? tailToEdge[u]
                    : Enumerable.Empty<Edge>();
            }
        }

        class Edge {
            public int From { get; private set; }
            public int To { get; private set; }
            public int Cost { get; private set; }

            public Edge(int from, int to, int cost) {
                From = from;
                To = to;
                Cost = cost;
            }

            public static Edge Parse(string input) {
                var parts = input.Split(' ').Take(3).Select(int.Parse).ToList();
                return new Edge(parts[0], parts[1], parts[2]);
            }
        }
    }
}
