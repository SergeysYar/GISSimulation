using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiSSim
{
    public class RoadGraph
    {
        public List<RoadEdge> Edges { get; set; }
        public List<RoadNode> Nodes { get; set; }
        public RoadGraph() 
        {
            Edges = new List<RoadEdge>();
            Nodes = new List<RoadNode>();
        }
        public void AddEdge(RoadEdge roadEdge)
        {
            int indexSource = Nodes.IndexOf(roadEdge.Source);
            int indexTarget = Nodes.IndexOf(roadEdge.Target);
            int indexEdges = Edges.IndexOf(roadEdge);
            if (indexTarget !=-1 && indexSource!=-1)
            {
                if (indexEdges!=-1)
                {
                    Console.WriteLine("Отрезок уже есть");
                }
                else
                {
                    Edges.Add(roadEdge);
                }
            }
            else
            {
                Console.WriteLine("Нет узлов");
            }
        }
        public void AddNode(RoadNode roadNode) 
        {
            int index = Nodes.IndexOf(roadNode);
            if (index != -1)
            {
                Console.WriteLine("Отрезок уже есть");
            }
            else
            {
                Nodes.Add(roadNode);
            }
        }
    }
}
