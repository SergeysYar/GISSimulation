using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;

namespace GiSSim
{
    //класс конструктора узла
    public class RoadNode
    {
        public int Id { get; set; }
        public string streetNames { get; set; }
        public Vector2D Coordinates { get; private set; }
        public RoadNode(int id, string StreetNames, Vector2D coordinates)
        {
            Id = id;
            streetNames = StreetNames;
            Coordinates = coordinates;
        }
    }
}
