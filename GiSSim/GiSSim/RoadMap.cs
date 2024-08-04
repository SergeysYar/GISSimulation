using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiSSim
{
    //класс конструктора карты
    public class RoadMap
    {
        public string Name { get; private set; }
        public List<RoadNode> Nodes { get; private set; }
        public List<RoadEdge> Edges { get; private set; }
        private RoadMap()
        {

            Nodes = new List<RoadNode>();
            Edges = new List<RoadEdge>();
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
