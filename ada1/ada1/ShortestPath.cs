using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ada1 {
    class ShortestPath {
        public static void Run() {
            var g = WeightedGraph.Parse(File.ReadLines("P5.txt"));
            var heap = new MinHeap<WeightedEdge, int>(e => e.Weight);
            var result = new Dictionary<int, int>();
            var paths = new Dictionary<int, List<int>>();
            var start = 1;
            result.Add(start, 0);
            foreach (var e in g.From(start)) {
                heap.Insert(e);
            }

            var lastAdd = start;
            while (heap.Any()) {
                var min = heap.Extract();
                if (result.ContainsKey(min.To)) {
                    continue;
                }

                lastAdd = min.To;
                result[min.To] = result[min.From] + min.Weight;
                foreach (var e in g.From(min.To)) {
                    heap.Insert(new WeightedEdge(start, e.To, result[min.To] + e.Weight));
                }
            }

            var distances = new List<int> { 7, 37, 59, 82, 99, 115, 133, 165, 188, 197 }
                .Select(t => result.ContainsKey(t) ? result[t] : 1000000);

            Console.WriteLine(String.Join(",", distances));
            Console.Read();
        }
    }

    class WeightedGraph {
        private readonly IDictionary<int, IList<WeightedEdge>> edges;

        public WeightedGraph(IDictionary<int, IList<WeightedEdge>> edges) {
            this.edges = edges;
        }

        public static WeightedGraph Parse(IEnumerable<string> input) {
            var edges = new Dictionary<int, IList<WeightedEdge>>();

            foreach (var line in input) {
                foreach (var e in Parse(line)) {
                    if (!edges.ContainsKey(e.From)) {
                        edges[e.From] = new List<WeightedEdge>();
                    }

                    edges[e.From].Add(e);
                }
            }

            return new WeightedGraph(edges);
        }

        public IList<WeightedEdge> From(int v) {
            return this.edges.ContainsKey(v)
                ? this.edges[v]
                : new List<WeightedEdge>();
        }


        private static IEnumerable<WeightedEdge> Parse(string input) {
            var parts = input.Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var from = int.Parse(parts[0]);
            for (var i = 1; i < parts.Length; i++) {
                var toAndWeight = parts[i].Split(',');
                var to = int.Parse(toAndWeight[0]);
                var weight = int.Parse(toAndWeight[1]);
                yield return new WeightedEdge(from, to, weight);
            }
        }

    }

    class WeightedEdge {
        public int From { get; private set; }
        public int To { get; private set; }
        public int Weight { get; private set; }

        public WeightedEdge(int from, int to, int weight) {
            this.From = from;
            this.To = to;
            this.Weight = weight;
        }

        public override string ToString() {
            return String.Format("{0}->{1},{2}", this.From, this.To, this.Weight);
        }
    }

    class MinHeap<T, TKey> where TKey : IComparable {
        private readonly IList<T> items;
        private readonly Func<T, TKey> getKey;
        private int LastIndex { get { return this.items.Count - 1; } }

        public int Count { get { return this.items.Count; } }

        public MinHeap(Func<T, TKey> getKey) {
            this.getKey = getKey;
            this.items = new List<T>();
        }

        public bool Any() {
            return this.items.Any();
        }

        public void Insert(T item) {
            this.items.Add(item);
            this.BubbleUp(this.LastIndex);
        }

        public T Extract() {
            var min = this.items.First();

            if (this.items.Count > 1) {
                this.Swap(0, this.LastIndex);
            }

            this.items.RemoveAt(this.LastIndex);

            if (this.items.Any()) {
                this.BubbleDown(0);
            }

            return min;
        }

        public T Peek() {
            return this.items.First();
        }

        private void BubbleDown(int i) {
            var leftIndex = this.Left(i);
            var rightIndex = this.Right(i);
            var leaf = leftIndex > this.LastIndex;
            if (leaf) {
                return;
            }

            var itemKey = this.getKey(this.items[i]);
            var leftKey = this.getKey(this.items[leftIndex]);

            var greaterThan = false;
            int swapIndex;
            if (rightIndex > this.LastIndex) {
                greaterThan = itemKey.CompareTo(leftKey) > 0;
                swapIndex = leftIndex;
            } else {
                var rightKey = this.getKey(this.items[rightIndex]);
                greaterThan = itemKey.CompareTo(leftKey) > 0
                           || itemKey.CompareTo(rightKey) > 0;
                swapIndex = leftKey.CompareTo(rightKey) <= 0
                    ? leftIndex
                    : rightIndex;
            }

            if (greaterThan) {
                this.Swap(i, swapIndex);
                this.BubbleDown(swapIndex);
            }
        }

        private void BubbleUp(int i) {
            if (i == 0) {
                return;
            }

            var itemKey = this.getKey(this.items[i]);

            var parentIndex = this.Parent(i);
            var parentKey = this.getKey(this.items[parentIndex]);

            var lessThan = itemKey.CompareTo(parentKey) < 0;
            if (lessThan) {
                this.Swap(i, parentIndex);
                this.BubbleUp(parentIndex);
            }
        }

        private int Parent(int i) {
            return (i - 1) / 2;
        }

        private int Left(int i) {
            return (2 * i) + 1;
        }

        private int Right(int i) {
            return (2 * i) + 2;
        }

        private void Swap(int i, int j) {
            var temp = this.items[i];
            this.items[i] = this.items[j];
            this.items[j] = temp;
        }

    }
}
