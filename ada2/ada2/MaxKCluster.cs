using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ada2 {
    class MaxKCluster {
        public static void Run() {
            Run1();
            Run2();
        }

        private static void Run1() {
            var edges = File
                .ReadAllLines("P2_clustering1.txt")
                .Skip(1)
                .Select(Edge.Parse)
                .OrderBy(e => e.Cost)
                .ToList();

            var vertices = new HashSet<int>();
            foreach (var e in edges) {
                vertices.Add(e.From);
                vertices.Add(e.To);
            }

            var uf = new UnionFind(vertices);

            var expectedNumClusters = 4;

            var numClusters = vertices.Count;

            var i = 0;
            for (; i < edges.Count && numClusters > expectedNumClusters; i++) {
                var e = edges[i];
                if (uf.Find(e.From) != uf.Find(e.To)) {
                    uf.Union(e.From, e.To);
                    numClusters--;
                }
            }

            var min = int.MaxValue;
            for (; i < edges.Count; i++) {
                var e = edges[i];
                if (uf.Find(e.From) != uf.Find(e.To)) {
                    min = Math.Min(min, e.Cost);
                }
            }

            Console.WriteLine(min);
        }

        public static void Run2() {
            var values = File
                .ReadAllLines("P2_clustering2.txt")
                .Skip(1)
                .Select(x => ParseInt(x, 24))
                .ToList();

            var uf = new UnionFind(values);
            var masks = CreateMasks(24);
            foreach (var u in values) {
                foreach (var m in masks) {
                    uf.MaybeUnion(u, u ^ m);
                }
            }

            Console.WriteLine(uf.ClusterCount);
        }

        private static int ParseInt(string input, int len) {
            var value = 0;
            for (var i = 0; i < len; i++) {
                var bit = input[i * 2];
                if (bit == '1') {
                    value = value | (1 << len - i - 1);
                }
            }

            return value;
        }

        private static List<int> CreateMasks(int len) {
            var masks = new List<int>();
            for (var i = 0; i < len; i++) {
                masks.Add(1 << i);
            }

            for (var i = 1; i < len; i++) {
                for (var j = 0; j < i; j++) {
                    var mask = 1 << i;
                    mask = mask | (1 << j);
                    masks.Add(mask);
                }
            }

            return masks;
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
                var parts = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
                return new Edge(parts[0], parts[1], parts[2]);
            }

            public override string ToString() {
                return String.Format("{0}-{1}: {2}", From, To, Cost);
            }
        }
        class UnionFind {
            private Dictionary<int, int> vertexToLeader;
            private Dictionary<int, IList<int>> leaderToVertices;

            public int ClusterCount { get { return leaderToVertices.Count; } }

            public UnionFind(IEnumerable<int> vertices) {
                vertexToLeader = new Dictionary<int, int>();
                leaderToVertices = new Dictionary<int, IList<int>>();

                foreach (var u in vertices) {
                    vertexToLeader[u] = u;
                    leaderToVertices[u] = new List<int> { u };
                }
            }

            public int Find(int u) {
                return vertexToLeader[u];
            }

            public void MaybeUnion(int u, int v) {
                if (!vertexToLeader.ContainsKey(v)) {
                    return;
                }

                Union(u, v);
            }

            public void Union(int u, int v) {
                var uLeader = vertexToLeader[u];
                var vLeader = vertexToLeader[v];

                if (uLeader == vLeader) {
                    return;
                }

                var uLeaderCount = leaderToVertices[uLeader].Count;
                var vLeaderCovnt = leaderToVertices[vLeader].Count;
                if (uLeaderCount > vLeaderCovnt) {
                    UpdateLeader(vLeader, uLeader);
                } else {
                    UpdateLeader(uLeader, vLeader);
                }

            }

            private void UpdateLeader(int oldLeader, int newLeader) {
                var followers = leaderToVertices[oldLeader];
                foreach (var f in followers) {
                    vertexToLeader[f] = newLeader;
                    leaderToVertices[newLeader].Add(f);
                }

                leaderToVertices.Remove(oldLeader);
            }
        }
    }
}
