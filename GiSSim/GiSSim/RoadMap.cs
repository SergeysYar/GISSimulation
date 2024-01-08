using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiSSim
{
    public class RoadMap
    {
        private Dictionary<int, RoadNode> nodes;
        private Dictionary<int, List<RoadEdge>> edges;
        public RoadMap()
        {
            nodes = new Dictionary<int, RoadNode>();
            edges = new Dictionary<int, List<RoadEdge>>();
        }
        public void AddNode(RoadNode node)
        {
            nodes[node.Id] = node;
            edges[node.Id] = new List<RoadEdge>();
        }

        public void AddEdge(RoadEdge edge)
        {
            if (!nodes.ContainsKey(edge.Source.Id))
                throw new ArgumentException("Edge source not found in graph.");
            if (!nodes.ContainsKey(edge.Target.Id))
                throw new ArgumentException("Edge target not found in graph.");

            edges[edge.Source.Id].Add(edge);
        }
    }
}
