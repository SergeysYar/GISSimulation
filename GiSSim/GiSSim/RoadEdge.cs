using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;

namespace GiSSim
{
    public class RoadEdge
    {
        public int Id { get; set; }
        public string NameGap { get; set; }
        public RoadNode Source { get; set; }
        public RoadNode Target { get; set; }
        public int TraficLightTimeSecond { get; set; }
        public int Lanes { get; set; }
        public double LengthM { get; set;}
        public int SpeedLimit { get; set; }
        public RoadEdge(int id, string nameGap, RoadNode source, RoadNode target, int traficLightTimeSecond, int lanes, double lenghtM, int speedLimit) 
        {
            Id = id;
            NameGap = nameGap;
            Source = source;
            Target = target;
            TraficLightTimeSecond = traficLightTimeSecond;
            Lanes = lanes;
            LengthM = lenghtM;
            SpeedLimit = speedLimit;
        }
    }
}
