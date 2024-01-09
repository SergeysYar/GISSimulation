using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GiSSim
{
    internal class DijkstraAlgorithm
    {
        public Dictionary<int, double> Dijkstra(RoadEdge source, Dictionary<int, RoadNode> nodes, Dictionary<int, List<RoadEdge>> edges)
        {
            var distances = new Dictionary<int, double>();
            var previous = new Dictionary<int, int>();
            var remaining = new HashSet<int>(nodes.Keys.Select(id => id));

            foreach (var node in nodes.Values)
            {
                distances[node.Id] = double.MaxValue;
            }
            distances[source.Id] = 0;

            while (remaining.Count > 0)
            {
                int currentNode = remaining.OrderBy(n => distances[n]).First();
                remaining.Remove(currentNode);

                foreach (var edge in edges[currentNode])
                {
                    int neighborId = edge.Target.Id;
                    if (remaining.Contains(neighborId))
                    {
                        double distThroughEdge = distances[currentNode] + edge.LengthM / edge.SpeedLimit * 3600 + edge.TraficLightTimeSecond/2;
                        if (distThroughEdge < distances[neighborId])
                        {
                            distances[neighborId] = distThroughEdge;
                            previous[neighborId] = currentNode;
                        }
                    }
                }
            }

            return distances;
        }
    }
}
