using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;


namespace GiSSim
{
    //загрузка или сохранение карты
    public class SaveAndLoadJSON
    {
        public static void SaveGraphToJSON(RoadMap roadGraph, string filePath)
        {
            RoadMap r = roadGraph;
            string json = JsonConvert.SerializeObject(roadGraph, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
        public static RoadMap LoadGraphToJSON(string filePath) 
        {
            string json = File.ReadAllText(filePath);
            RoadMap graph = JsonConvert.DeserializeObject<RoadMap>(json);
            return graph;
        }
    }
}
