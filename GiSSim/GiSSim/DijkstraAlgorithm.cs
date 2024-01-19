using QuickGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GiSSim
{

  //класс поиска кратчайшего пути, с помощью дейкстры 
    public class DijkstraAlgorithm
    {
        // Результат, содержащий путь, расстояние и время
        public class ShortestPathResult
        {
            public List<RoadNode> PathNode { get; set; }
            public List<RoadEdge> PathEdge { get; set; }
            public double Distance { get; set; }
            public double Time { get; set; }
        }

        public ShortestPathResult FindShortestPath(RoadMap roadMap, RoadNode startNode, RoadNode targetNode)
        {
            Dictionary<RoadNode, double> distances = new Dictionary<RoadNode, double>();
            Dictionary<RoadNode, double> times = new Dictionary<RoadNode, double>();
            Dictionary<RoadNode, RoadNode> previousNodes = new Dictionary<RoadNode, RoadNode>();
            List<RoadNode> unvisitedNodes = new List<RoadNode>();
            List<RoadEdge> pathEdge = new List<RoadEdge>();

            // Инициализация начальных расстояний и времён
            foreach (RoadNode node in roadMap.Nodes)
            {
                distances[node] = double.MaxValue;
                times[node] = double.MaxValue;
                previousNodes[node] = null;
                unvisitedNodes.Add(node);
            }

            distances[startNode] = 0;
            times[startNode] = 0;

            while (unvisitedNodes.Count > 0)
            {
                RoadNode currentNode = GetNodeWithMinDistance(distances, unvisitedNodes);
                unvisitedNodes.Remove(currentNode);

                if (currentNode == targetNode)
                    break;

                //foreach (RoadEdge edge in roadMap.Edges)
                //{
                //    if (edge.Source == currentNode)
                //    {
                //        double distanceThroughCurrentNode = distances[currentNode] + edge.LengthM;
                //        double timeThroughCurrentNode = times[currentNode] + edge.LengthM / (edge.SpeedLimit*5/18);

                //        if (distanceThroughCurrentNode < distances[edge.Target])
                //        {
                //            distances[edge.Target] = distanceThroughCurrentNode;
                //            times[edge.Target] = timeThroughCurrentNode;
                //            previousNodes[edge.Target] = currentNode;
                //        }
                //    }

                //}
                foreach (RoadEdge edge in roadMap.Edges)
                {
                    if (edge.Source == currentNode)
                    {
                        double distanceThroughCurrentNode = distances[currentNode] + edge.LengthM;
                        double timeThroughCurrentNode = times[currentNode] + edge.LengthM / (edge.SpeedLimit * 5 / 18);

                        if (distanceThroughCurrentNode < distances[edge.Target])
                        {
                            distances[edge.Target] = distanceThroughCurrentNode;
                            times[edge.Target] = timeThroughCurrentNode;
                            previousNodes[edge.Target] = currentNode;

                            // Добавление пройденного ребра в список pathEdge
                            if (previousNodes[edge.Target] == currentNode)
                            {
                                pathEdge.Add(edge);
                            }
                        }
                    }
                }

            }

            List<RoadNode> path = BuildPath(targetNode, previousNodes);
            return new ShortestPathResult
            {
                PathNode = path,
                PathEdge = pathEdge,
                Distance = distances[targetNode],
                Time = times[targetNode]
            };

        }
        private RoadNode GetNodeWithMinDistance(Dictionary<RoadNode, double> distances, List<RoadNode> nodes)
        {
            double minDistance = double.MaxValue;
            RoadNode minNode = null;

            foreach (RoadNode node in nodes)
            {
                if (distances[node] < minDistance)
                {
                    minDistance = distances[node];
                    minNode = node;
                }
            }

            return minNode;
        }

        private List<RoadNode> BuildPath(RoadNode targetNode, Dictionary<RoadNode, RoadNode> previousNodes)
        {
            List<RoadNode> path = new List<RoadNode>();
            RoadNode currentNode = targetNode;

            while (currentNode != null)
            {
                path.Insert(0, currentNode);
                currentNode = previousNodes[currentNode];
            }

            return path;
        }

    }

}


