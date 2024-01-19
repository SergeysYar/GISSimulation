using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiSSim
{
    //класс создания рандомных путей
    public class RandomPathGenerator
    {
        public static List<Tuple<RoadEdge, RoadEdge>> GenerateRandomPaths(RoadMap roadMap)
        {
            List<Tuple<RoadEdge, RoadEdge>> paths = new List<Tuple<RoadEdge, RoadEdge>>();
            int[] occupied = new int[roadMap.Edges.Count];
            Random rnd = new Random();
            foreach (var edge in roadMap.Edges)
            {
                int i = 0;
                while (i< edge.Outgoing)
                {
                    int random = rnd.Next(roadMap.Edges.Count);
                    if (occupied[random] != roadMap.Edges[random].Incoming && edge.Id!= roadMap.Edges[random].Id)
                    {
                        occupied[random]++;
                        i++;
                        Tuple<RoadEdge, RoadEdge> tuple = new Tuple<RoadEdge, RoadEdge>(edge, roadMap.Edges[random]);

                        paths.Add(tuple);
                    }
                }
            }
            return paths;
        }
    }

}
