using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiSSim
{
    public class Car
    {
        public int Name { get; private set; }    
        public List<RoadEdge> Path { get; private set; }
        public int CurrentEdgeIndex { get; private set; }
        public int TimeOnCurrentEdge { get; set; }
        public Car(int name, List<RoadEdge> path) 
        { 
            Name = name;
            Path= path; 
            CurrentEdgeIndex = 0;
            TimeOnCurrentEdge = 1;
        }    
        public void MoveToNextEdge()
        {
            if (CurrentEdgeIndex < Path.Count - 1)
            {
                CurrentEdgeIndex++;
            }
        }
        public RoadEdge GetCurrentEdge() 
        {
            return Path[CurrentEdgeIndex];
        }
    }
}
