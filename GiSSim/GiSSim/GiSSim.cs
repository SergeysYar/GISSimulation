using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GiSSim
{
    public class GiSSim
    {
        private RoadMap roadMap;
        public GiSSim(string Name) 
        {
            roadMap = new RoadMap.Builder(Name).Build();
        }
        public void AddNode(string Name,double x, double y)
        {
            RoadNode node = new RoadNode(roadMap.Nodes.Count, Name, new Vector2D(x, y));
            roadMap.Nodes.Add(node);
        }
        public void RemoveNode(RoadNode Node)
        {
            roadMap.Nodes.Remove(Node);
        }
        public void AddEdge(string Name, int nodeA, int nodeB, int TrafficLightTimeSecond, int Lanes, int LengthM, int SpeedLimit, int IncomingCar, int OutgoingCar)
        {
            RoadEdge edge = new RoadEdge.Builder()
                        .WithId(roadMap.Edges.Count)
                        .WithNameGap(Name)
                        .WithSource(roadMap.Nodes[nodeA])
                        .WithTarget(roadMap.Nodes[nodeB])
                        .WithTrafficLightTimeSecond(TrafficLightTimeSecond)
                        .WithLanes(Lanes)
                        .WithLengthM(LengthM)
                        .WithSpeedLimit(SpeedLimit)
                        .WithIncoming(IncomingCar)
                        .WithOutgoing(OutgoingCar)
                        .Build();
            roadMap.Edges.Add(edge);
        }
        public void RemoveEdge(RoadEdge edge)
        {
            roadMap.Edges.Remove(edge);
        }
        public void SaveRoadMap(string filename)
        {
            SaveAndLoadJSON.SaveGraphToJSON(roadMap, filename);
        }
        public void LoadRoadMap(string filename)
        {
            roadMap=SaveAndLoadJSON.LoadGraphToJSON(filename);
        }
        public RoadMap StartSimulation(int iteration, int minutes)
        {
            List<Tuple<RoadEdge, RoadEdge>> paths = RandomPathGenerator.GenerateRandomPaths(roadMap);//создание рандомных путей
            List<DijkstraAlgorithm.ShortestPathResult> DijPathList = new List<DijkstraAlgorithm.ShortestPathResult>();//список всего, что вернула дейкстра
            int i = 0;
            foreach (var item in paths)// работа дейкстры
            {
                i++;
                DijkstraAlgorithm dijkstra = new DijkstraAlgorithm();
                RoadNode startNode = item.Item1.Source;
                RoadNode targetNode = item.Item2.Target;
                DijkstraAlgorithm.ShortestPathResult result = dijkstra.FindShortestPath(roadMap, startNode, targetNode);
                DijPathList.Add(result);
            }
            List<Car> cars = new List<Car>();
            int j = 0;
            foreach (var item in DijPathList)//создание машин
            {
                Car car = new(j, item.PathEdge);
                cars.Add(car);
                j++;
            }
            Simulation simulation = new Simulation(roadMap, iteration, minutes);//создание параметров симуляции
            foreach (var item in cars)//добавление машин в симуляцию
            {
                simulation.AddCar(item);
            }
            List<SimulationState> simulationStates = simulation.RunSimulation();//запуск симуляции

            for (int k = 0; k < roadMap.Edges.Count; k++)
            {
                for (int l = 0; l < iteration; l++)
                {
                    roadMap.Edges[k].WorkLoadsList.Add(0);
                }
            }
            int kostil = 0;
            // Вывод результатов
            foreach (SimulationState state in simulationStates)
            {
                foreach (KeyValuePair<int, double> edgeCongestion in state.EdgeCongestion)
                {
                    roadMap.Edges[edgeCongestion.Key].WorkLoadsList[kostil] =edgeCongestion.Value;
                }
                kostil++;
            }
            return roadMap;
        }
    }
}
