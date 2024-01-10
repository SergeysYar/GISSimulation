using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiSSim
{
    //public class RoadMap
    //{
    //    public Dictionary<int, RoadNode> nodes;
    //    public Dictionary<int, List<RoadEdge>> edges;
    //    public RoadMap()
    //    {
    //        nodes = new Dictionary<int, RoadNode>();
    //        edges = new Dictionary<int, List<RoadEdge>>();
    //    }
    //    public void AddNode(RoadNode node)
    //    {
    //        nodes[node.Id] = node;
    //        edges[node.Id] = new List<RoadEdge>();
    //    }

    //    public void AddEdge(RoadEdge edge)
    //    {
    //        if (!nodes.ContainsKey(edge.Source.Id))
    //            throw new ArgumentException("Edge source not found in graph.");
    //        if (!nodes.ContainsKey(edge.Target.Id))
    //            throw new ArgumentException("Edge target not found in graph.");

    //        edges[edge.Source.Id].Add(edge);
    //    }
    //}
    public class RoadMap
    {
        public string Name { get; private set; }
        public List<RoadNode> Nodes { get; private set; }
        public List<RoadEdge> Edges { get; private set; }
        private Dictionary<RoadNode, List<RoadEdge>> adjacencyList;

        private RoadMap()
        {
            Nodes = new List<RoadNode>();
            Edges = new List<RoadEdge>();
        }
        public List<RoadEdge> GetOutgoingEdges(RoadNode node)
        {
            if (adjacencyList.ContainsKey(node))
            {
                return adjacencyList[node];
            }

            return new List<RoadEdge>(); // Если узел отсутствует в adjacencyList, возвращаем пустой список ребер
        }

        public class Builder
        {
            private RoadMap roadMap;

            public Builder(string name)
            {
                roadMap = new RoadMap();
                roadMap.Name = name;
            }

            public Builder AddNode(RoadNode node)
            {
                roadMap.Nodes.Add(node);
                return this;
            }

            public Builder AddEdge(RoadEdge edge)
            {
                roadMap.Edges.Add(edge);
                return this;
            }

            public RoadMap Build()
            {
                return roadMap;
            }
        }
    }


}
