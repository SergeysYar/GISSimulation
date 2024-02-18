using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;


namespace GiSSim
{
    //класс конструктора квартала
    public class RoadEdge
    {
        public int Id { get; private set; }
        public string NameGap { get; private set; }
        public RoadNode Source { get; private set; }
        public RoadNode Target { get; private set; }
        public int TraficLightTimeSecond { get; private set; }
        public int Lanes { get; private set; }
        public double LengthM { get; private set;}
        public int SpeedLimit { get; private set; }
        public int Incoming { get; private set; }
        public int Outgoing { get; private set; }
        public List<double> WorkLoadsList { get; private set; }
        //public List<SimulationState>  SimulationStates { get; set; }
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
