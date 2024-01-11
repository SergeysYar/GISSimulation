using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiSSim
{
    public class DijkstraAlgorithmEdge
    {
        public List<RoadEdge> FindShortestPath(List<RoadNode> nodes, List<RoadEdge> edges, RoadNode startNode, RoadNode endNode)
        {
            Dictionary<RoadNode, int> distances = new Dictionary<RoadNode, int>();
            Dictionary<RoadNode, RoadEdge> previousEdges = new Dictionary<RoadNode, RoadEdge>();
            HashSet<RoadNode> visitedNodes = new HashSet<RoadNode>();
            PriorityQueue<RoadNode> priorityQueue = new PriorityQueue<RoadNode>();

            foreach (RoadNode node in nodes)
            {
                if (node == startNode)
                    distances[node] = 0;
                else
                    distances[node] = int.MaxValue;

                priorityQueue.Enqueue(node, distances[node]);
            }

            while (priorityQueue.Count > 0)
            {
                RoadNode currentNode = priorityQueue.Dequeue();

                if (currentNode == endNode)
                    break;

                if (visitedNodes.Contains(currentNode))
                    continue;

                visitedNodes.Add(currentNode);

                foreach (RoadEdge edge in edges)
                {
                    if (edge.Source == currentNode)
                    {
                        int distance = distances[currentNode] + Convert.ToInt16(edge.LengthM);

                        if (distance < distances[edge.Target])
                        {
                            distances[edge.Target] = distance;
                            previousEdges[edge.Target] = edge;
                            priorityQueue.EnqueueOrUpdate(edge.Target, distance);
                        }
                    }
                }
            }

            if (!previousEdges.ContainsKey(endNode))
                return null;

            List<RoadEdge> shortestPath = new List<RoadEdge>();
            RoadNode current = endNode;

            while (current != startNode)
            {
                RoadEdge previousEdge = previousEdges[current];
                shortestPath.Insert(0, previousEdge);
                current = previousEdge.Source;
            }

            return shortestPath;
        }
    }

    public class PriorityQueue<T>
    {
        private SortedDictionary<int, Queue<T>> _dictionary;

        public int Count { get; private set; }

        public PriorityQueue()
        {
            _dictionary = new SortedDictionary<int, Queue<T>>();
            Count = 0;
        }

        public void Enqueue(T item, int priority)
        {
            if (!_dictionary.ContainsKey(priority))
                _dictionary[priority] = new Queue<T>();

            _dictionary[priority].Enqueue(item);
            Count++;
        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Priority queue is empty.");

            var queue = _dictionary.First().Value;
            T item = queue.Dequeue();
            if (queue.Count == 0)
                _dictionary.Remove(_dictionary.First().Key);
            Count--;

            return item;
        }

        public void EnqueueOrUpdate(T item, int priority)
        {
            if (!_dictionary.ContainsKey(priority))
                _dictionary[priority] = new Queue<T>();

            _dictionary[priority].Enqueue(item);
            Count++;
        }
    }
}
