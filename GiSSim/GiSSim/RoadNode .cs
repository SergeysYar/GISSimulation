using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;

namespace GiSSim
{
    public class RoadNode
    {
        public int Id { get; set; }
        public string streetNames { get; set; }
        public RoadNode(int id, string StreetNames)
        {
            Id = id;
            streetNames= StreetNames;
        }
    }
}
