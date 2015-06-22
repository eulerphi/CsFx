using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.TreesAndGraphs {
    class GraphNode {
        public IList<GraphNode> AdjacentNodes { get; private set; }
        public int Value { get; set; }

        public GraphNode(params GraphNode[] adjacentNodes) {
            this.AdjacentNodes = new List<GraphNode>(adjacentNodes);
        }
    }
}
