
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GiSSim
{

    ////класс поиска кратчайшего пути, с помощью дейкстры 
    //  public class DijkstraAlgorithm
    //  {
    //      // Результат, содержащий путь, расстояние и время
    //      public class ShortestPathResult
    //      {
    //          public List<RoadNode> PathNode { get; set; }
    //          public List<RoadEdge> PathEdge { get; set; }
    //          public double Distance { get; set; }
    //          public double Time { get; set; }
    //      }

    //      public ShortestPathResult FindShortestPath(RoadMap roadMap, RoadNode startNode, RoadNode targetNode)
    //      {
    //          Dictionary<RoadNode, double> distances = new Dictionary<RoadNode, double>();
    //          Dictionary<RoadNode, double> times = new Dictionary<RoadNode, double>();
    //          Dictionary<RoadNode, RoadNode> previousNodes = new Dictionary<RoadNode, RoadNode>();
    //          List<RoadNode> unvisitedNodes = new List<RoadNode>();
    //          List<RoadEdge> pathEdge = new List<RoadEdge>();

    //          // Инициализация начальных расстояний и времён
    //          foreach (RoadNode node in roadMap.Nodes)
    //          {
    //              distances[node] = double.MaxValue;
    //              times[node] = double.MaxValue;
    //              previousNodes[node] = null;
    //              unvisitedNodes.Add(node);
    //          }

    //          distances[startNode] = 0;
    //          times[startNode] = 0;

    //          while (unvisitedNodes.Count > 0)
    //          {
    //              RoadNode currentNode = GetNodeWithMinDistance(distances, unvisitedNodes);
    //              unvisitedNodes.Remove(currentNode);

    //              if (currentNode == targetNode)
    //                  break;

    //              foreach (RoadEdge edge in roadMap.Edges)
    //              {
    //                  if (edge.Source == currentNode)
    //                  {
    //                      double distanceThroughCurrentNode = distances[currentNode] + edge.LengthM;
    //                      double timeThroughCurrentNode = times[currentNode] + edge.LengthM / (edge.SpeedLimit * 5 / 18);

    //                      if (distanceThroughCurrentNode < distances[edge.Target])
    //                      {
    //                          distances[edge.Target] = distanceThroughCurrentNode;
    //                          times[edge.Target] = timeThroughCurrentNode;
    //                          previousNodes[edge.Target] = currentNode;

    //                          // Добавление пройденного ребра в список pathEdge
    //                          if (previousNodes[edge.Target] == currentNode)
    //                          {
    //                              pathEdge.Add(edge);
    //                          }
    //                      }
    //                  }
    //              }

    //          }

    //          List<RoadNode> path = BuildPath(targetNode, previousNodes);
    //          return new ShortestPathResult
    //          {
    //              PathNode = path,
    //              PathEdge = pathEdge,
    //              Distance = distances[targetNode],
    //              Time = times[targetNode]
    //          };

    //      }
    //      private RoadNode GetNodeWithMinDistance(Dictionary<RoadNode, double> distances, List<RoadNode> nodes)
    //      {
    //          double minDistance = double.MaxValue;
    //          RoadNode? minNode = null;

    //          foreach (RoadNode node in nodes)
    //          {
    //              if (distances[node] < minDistance)
    //              {
    //                  minDistance = distances[node];
    //                  minNode = node;
    //              }
    //          }

    //          return minNode;
    //      }

    //      private List<RoadNode> BuildPath(RoadNode targetNode, Dictionary<RoadNode, RoadNode> previousNodes)
    //      {
    //          List<RoadNode> path = new List<RoadNode>();
    //          RoadNode currentNode = targetNode;

    //          while (currentNode != null)
    //          {
    //              path.Insert(0, currentNode);
    //              currentNode = previousNodes[currentNode];
    //          }

    //          return path;
    //      }

    //  }
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

        // Метод поиска кратчайшего пути
        public ShortestPathResult FindShortestPath(RoadMap roadMap, RoadNode startNode, RoadNode targetNode)
        {
            Dictionary<int, double> distances = new Dictionary<int, double>();
            Dictionary<int, double> times = new Dictionary<int, double>();
            Dictionary<int, RoadNode> previousNodes = new Dictionary<int, RoadNode>();
            HashSet<RoadNode> unvisitedNodes = new HashSet<RoadNode>(roadMap.Nodes);
            List<RoadEdge> pathEdge = new List<RoadEdge>();

            // Инициализация начальных расстояний и времён
            foreach (RoadNode node in roadMap.Nodes)
            {
                distances[node.Id] = double.MaxValue;
                times[node.Id] = double.MaxValue;
                previousNodes[node.Id] = null;
            }
            RoadNode StartNode = startNode;
            distances[startNode.Id] = 0;
            times[startNode.Id] = 0;

            while (unvisitedNodes.Count > 0)
            {
                RoadNode currentNode = GetNodeWithMinDistance(distances, unvisitedNodes);

                if (currentNode == null)
                    break;

                unvisitedNodes.Remove(currentNode);

                if (currentNode == targetNode)
                    break;

                foreach (RoadEdge edge in roadMap.Edges)
                {
                    if (edge.Source.Id == currentNode.Id)
                    {
                        double distanceThroughCurrentNode = distances[currentNode.Id] + edge.LengthM;
                        double timeThroughCurrentNode = times[currentNode.Id] + edge.LengthM / (edge.SpeedLimit * 5 / 18);

                        if (distanceThroughCurrentNode < distances[edge.Target.Id])
                        {
                            distances[edge.Target.Id] = distanceThroughCurrentNode;
                            times[edge.Target.Id] = timeThroughCurrentNode;
                            previousNodes[edge.Target.Id] = currentNode;

                            // Добавление пройденного ребра в список pathEdge
                            pathEdge.Add(edge);
                        }
                    }
                }
            }

            List<RoadNode> path = BuildPath(targetNode, previousNodes);
            return new ShortestPathResult
            {
                PathNode = path,
                PathEdge = pathEdge,
                Distance = distances[targetNode.Id],
                Time = times[targetNode.Id]
            };
        }

        // Метод получения узла с минимальным расстоянием
        private RoadNode GetNodeWithMinDistance(Dictionary<int, double> distances, HashSet<RoadNode> nodes)
        {
            RoadNode minNode = null;
            double minDistance = double.MaxValue;

            foreach (RoadNode node in nodes)
            {
                if (distances[node.Id] < minDistance)
                {
                    minDistance = distances[node.Id];
                    minNode = node;
                }
            }

            return minNode;
        }

        // Метод построения пути
        private List<RoadNode> BuildPath(RoadNode targetNode, Dictionary<int, RoadNode> previousNodes)
        {
            List<RoadNode> path = new List<RoadNode>();
            RoadNode currentNode = targetNode;

            while (currentNode != null)
            {
                path.Insert(0, currentNode);
                currentNode = previousNodes[currentNode.Id];
            }

            return path;
        }
    }

}


