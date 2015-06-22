using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.ArraysAndStrings;

namespace CsFxCtCITests.ArraysAndStrings {
    [TestClass]
    public class Problem8Tests {
        [TestMethod]
        public void IsRotation_True() {
            var examples = new Tuple<string, string>[] {
                Tuple.Create("a", "a"),
                Tuple.Create("ab", "ba"),
                Tuple.Create("abc", "cab")
            };

            foreach (var example in examples) {
                Assert.IsTrue(Problem8.IsRotaion(example.Item1, example.Item2));
            }
        }

        [TestMethod]
        public void IsRotation_False() {
            var examples = new Tuple<string, string>[] {
                Tuple.Create(String.Empty, String.Empty),
                Tuple.Create("a", "b"),
                Tuple.Create("a", "aa"),
                Tuple.Create("aa", "a")
            };

            foreach (var example in examples) {
                Assert.IsFalse(Problem8.IsRotaion(example.Item1, example.Item2));
            }
        }
    }
}
