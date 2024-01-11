using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiSSim
{
    public class Car
    {
        public string Name { get; private set; }    
        public List<RoadEdge> Path { get; private set; }
        public int CurrentEdgeIndex { get; private set; }
        public Car(string name, List<RoadEdge> path) 
        { 
            Name = name;
            Path= path; 
            CurrentEdgeIndex = 0;  
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
