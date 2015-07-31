using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ada2 {
    class Knapsack {
        public static void Run() {
            Run1();
            Run2();
        }

        private static void Run1() {
            var lines = File.ReadAllLines("P3_knapsack1.txt");
            var capacity = lines[0].Split(' ').Take(1).Select(int.Parse).First();
            var items = lines.Skip(1).Select(Item.Parse).ToList();

            var result = KS2dArray(items, capacity);
            Console.WriteLine(result);
        }

        private static void Run2() {
            var lines = File.ReadAllLines("P3_knapsack2.txt");
            var capacity = lines[0].Split(' ').Take(1).Select(int.Parse).First();
            var items = lines.Skip(1).Select(Item.Parse).ToList();
            var memo = new Dictionary<Tuple<int, int>, int>();

            var input = Tuple.Create(items.Count, capacity);
            var result = KSRecursive(input, items, memo);
            //var result = KS1dArray(items, capacity);

            Console.WriteLine(result);
        }

        private static int KS2dArray(List<Item> items, int capacity) {
            var table = new int[items.Count + 1, capacity + 1];
            for (var i = 1; i < items.Count + 1; i++) {
                for (var j = 0; j < capacity + 1; j++) {
                    var item = items[i - 1];

                    var withoutItemTotal = table[i - 1, j];
                    var withItemTotal = item.Weight <= j
                        ? table[i - 1, j - item.Weight] + item.Value
                        : int.MinValue;

                    table[i, j] = Math.Max(withoutItemTotal, withItemTotal);
                }
            }

            return table[items.Count, capacity];
        }

        private static int KSRecursive(Tuple<int, int> input, List<Item> items, Dictionary<Tuple<int, int>, int> memo) {
            if (memo.ContainsKey(input)) {
                return memo[input];
            }

            var i = input.Item1;
            var c = input.Item2;
            if (i <= 0 || c <= 0) {
                return 0;
            }

            var item = items[i - 1];
            var without = KSRecursive(Tuple.Create(i - 1, c), items, memo);
            var with = item.Weight <= c
                ? KSRecursive(Tuple.Create(i - 1, c - item.Weight), items, memo) + item.Value
                : int.MinValue;

            memo[input] = Math.Max(without, with);
            return memo[input];
        }

        private static int KS1dArray(List<Item> items, int capacity) {
            var table = new int[capacity + 1];
            for (var i = 1; i < items.Count + 1; i++) {
                for (var j = capacity; j >= 0; j--) {
                    var item = items[i - 1];

                    var withoutItemTotal = table[j];
                    var withItemTotal = item.Weight <= j
                        ? table[j - item.Weight] + item.Value
                        : int.MinValue;

                    table[j] = Math.Max(withoutItemTotal, withItemTotal);
                }
            }

            return table[capacity];
        }

        class Item {
            public int Value { get; private set; }
            public int Weight { get; private set; }

            public Item(int value, int weight) {
                Value = value;
                Weight = weight;
            }

            public static Item Parse(string input) {
                var parts = input.Split(' ').Take(2).Select(int.Parse).ToList();
                return new Item(parts[0], parts[1]);
            }

            public override string ToString() {
                return String.Format("{0} for {1}", Value, Weight);
            }
        }
    }
}
