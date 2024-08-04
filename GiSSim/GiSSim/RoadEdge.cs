using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GiSSim
{
    //класс конструктора квартала
    public class RoadEdge
    {
        public int Id { get;  set; }
        public string NameGap { get;  set; }
        public RoadNode Source { get;  set; }
        public RoadNode Target { get;  set; }
        public int TraficLightTimeSecond { get;  set; }
        public int Lanes { get;  set; }
        public double LengthM { get;  set;}
        public int SpeedLimit { get;  set; }
        public int Incoming { get;  set; }
        public int Outgoing { get;  set; }
        [JsonIgnore]
        public List<double> WorkLoadsList { get;  set; }
        public RoadEdge() 
        {
            WorkLoadsList= new List<double>();
        }
        public class Builder
        {
            private RoadEdge _roadEdge = new RoadEdge();
            private List<SimulationState> SimulationStates = new List<SimulationState>();

            public Builder WithId(int id)
            {
                _roadEdge.Id = id;
                return this;
            }

            public Builder WithNameGap(string nameGap)
            {
                _roadEdge.NameGap = nameGap;
                return this;
            }

            public Builder WithSource(RoadNode source)
            {
                _roadEdge.Source = source;
                return this;
            }

            public Builder WithTarget(RoadNode target)
            {
                _roadEdge.Target = target;
                return this;
            }

            public Builder WithTrafficLightTimeSecond(int trafficLightTimeSecond)
            {
                _roadEdge.TraficLightTimeSecond = trafficLightTimeSecond;
                return this;
            }

            public Builder WithLanes(int lanes)
            {
                _roadEdge.Lanes = lanes;
                return this;
            }

            public Builder WithLengthM(double lengthM)
            {
                _roadEdge.LengthM = lengthM;
                return this;
            }

            public Builder WithSpeedLimit(int speedLimit)
            {
                _roadEdge.SpeedLimit = speedLimit;
                return this;
            }

            public Builder WithIncoming(int incoming)
            {
                _roadEdge.Incoming = incoming;
                return this;
            }

            public Builder WithOutgoing(int outgoing)
            {
                _roadEdge.Outgoing = outgoing;
                return this;
            }
            public Builder AddSimulationStates(SimulationState simulationState)
            {
                this.SimulationStates.Add(simulationState);
                return this;
            }

            public RoadEdge Build()
            {
                return _roadEdge;
            }
        }
    }
}
