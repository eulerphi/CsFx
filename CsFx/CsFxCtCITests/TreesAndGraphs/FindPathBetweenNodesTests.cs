using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.TreesAndGraphs;

namespace CsFxCtCITests.TreesAndGraphs {
    [TestClass]
    public class FindPathBetweenNodesTests {
        [TestMethod]
        public void TestFind() {
            var b = new GraphNode();
            var a = new GraphNode();
            a.AdjacentNodes.Add(
                new GraphNode(
                    new GraphNode(a)));
            a.AdjacentNodes.Add(
                new GraphNode(b));

            Assert.IsTrue(FindPathBetweenGraphNodes.FindDFS(a, b));
            Assert.IsFalse(FindPathBetweenGraphNodes.FindDFS(a, new GraphNode()));

            Assert.IsTrue(FindPathBetweenGraphNodes.FindBFS(a, b));
            Assert.IsFalse(FindPathBetweenGraphNodes.FindBFS(a, new GraphNode()));
        }
    }
}
