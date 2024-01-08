using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using QuickGraph;

namespace GiSSim
{
    public class SaveAndLoadJSON
    {
        public static void SaveGraphToJSON(RoadGraph roadGraph, string filePath)
        {
            string json = JsonConvert.SerializeObject(roadGraph, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
        public static RoadGraph LoadGraphToJSON(string filePath) 
        {
            string json = File.ReadAllText(filePath);
            RoadGraph graph = JsonConvert.DeserializeObject<RoadGraph>(json);
            return graph;
        }
    }
}
