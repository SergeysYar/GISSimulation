using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using GiSSim;
using QuickGraph;

public class Program
{
    public static void Main(string[] args)
    {

        RoadNode nodeA = new RoadNode(1, "Intersection A");
        RoadNode nodeB = new RoadNode(2, "Intersection B");
        RoadNode nodeC = new RoadNode(3, "Intersection C");
        RoadNode nodeD = new RoadNode(4, "Intersection D");
        RoadNode nodeE = new RoadNode(5, "Intersection E");
        //  RoadNode nodeF = new RoadNode(6, "Intersection F");
        //  RoadNode nodeG = new RoadNode(7, "Intersection G");


        RoadEdge edge1 = new RoadEdge.Builder()
            .WithId(1)
            .WithNameGap("Street A-B")
            .WithSource(nodeA)
            .WithTarget(nodeB)
            .WithTrafficLightTimeSecond(30)
            .WithLanes(2)
            .WithLengthM(150)
            .WithSpeedLimit(50)
            .WithIncoming(1000)
            .WithOutgoing(750)
            .Build();

        RoadEdge edge2 = new RoadEdge.Builder()
    .WithId(1)
    .WithNameGap("Street B-A")
    .WithSource(nodeB)
    .WithTarget(nodeA)
    .WithTrafficLightTimeSecond(30)
    .WithLanes(2)
    .WithLengthM(150)
    .WithSpeedLimit(50)
            .WithIncoming(100)
            .WithOutgoing(75)
    .Build();
        RoadEdge edge3 = new RoadEdge.Builder()
    .WithId(1)
    .WithNameGap("Street B-C")
    .WithSource(nodeB)
    .WithTarget(nodeC)
    .WithTrafficLightTimeSecond(30)
    .WithLanes(2)
    .WithLengthM(150)
    .WithSpeedLimit(50)
            .WithIncoming(1000)
            .WithOutgoing(750)
    .Build();
        RoadEdge edge4 = new RoadEdge.Builder()
    .WithId(1)
    .WithNameGap("Street C-B")
    .WithSource(nodeC)
    .WithTarget(nodeB)
    .WithTrafficLightTimeSecond(30)
    .WithLanes(2)
    .WithLengthM(150)
    .WithSpeedLimit(50)
            .WithIncoming(500)
            .WithOutgoing(150)
    .Build();
        RoadEdge edge5 = new RoadEdge.Builder()
    .WithId(1)
    .WithNameGap("Street C-E")
    .WithSource(nodeC)
    .WithTarget(nodeE)
    .WithTrafficLightTimeSecond(30)
    .WithLanes(2)
    .WithLengthM(150)
    .WithSpeedLimit(50)
            .WithIncoming(2000)
            .WithOutgoing(1550)
    .Build();
        RoadEdge edge6 = new RoadEdge.Builder()
    .WithId(1)
    .WithNameGap("Street E-D")
    .WithSource(nodeE)
    .WithTarget(nodeD)
    .WithTrafficLightTimeSecond(30)
    .WithLanes(2)
    .WithLengthM(150)
    .WithSpeedLimit(50)
            .WithIncoming(1000)
            .WithOutgoing(75)
    .Build();
        RoadEdge edge7 = new RoadEdge.Builder()
    .WithId(1)
    .WithNameGap("Street D-B")
    .WithSource(nodeD)
    .WithTarget(nodeB)
    .WithTrafficLightTimeSecond(30)
    .WithLanes(2)
    .WithLengthM(150)
    .WithSpeedLimit(50)
            .WithIncoming(100)
            .WithOutgoing(750)
    .Build();
        RoadEdge edge8 = new RoadEdge.Builder()
    .WithId(1)
    .WithNameGap("Street D-A")
    .WithSource(nodeD)
    .WithTarget(nodeA)
    .WithTrafficLightTimeSecond(30)
    .WithLanes(2)
    .WithLengthM(150)
    .WithSpeedLimit(50)
            .WithIncoming(1000)
            .WithOutgoing(750)
    .Build();

        //  RoadEdge edge2 = new RoadEdge.Builder()
        //      .WithId(2)
        //      .WithNameGap("Street B-C")
        //      .WithSource(nodeB)
        //      .WithTarget(nodeC)
        //      .WithTrafficLightTimeSecond(20)
        //      .WithLanes(2)
        //      .WithLengthM(200)
        //      .WithSpeedLimit(50)
        //      .WithIncoming(10)
        //      .WithOutgoing(10)
        //      .Build();

        //  RoadEdge edge3 = new RoadEdge.Builder()
        //      .WithId(3)
        //      .WithNameGap("Street C-D")
        //      .WithSource(nodeC)
        //      .WithTarget(nodeD)
        //      .WithTrafficLightTimeSecond(25)
        //      .WithLanes(2)
        //      .WithLengthM(300)
        //      .WithSpeedLimit(40)
        //      .WithIncoming(15)
        //      .WithOutgoing(10)
        //      .Build();

        //  RoadEdge edge4 = new RoadEdge.Builder()
        //      .WithId(4)
        //      .WithNameGap("Street A-D")
        //      .WithSource(nodeA)
        //      .WithTarget(nodeD)
        //      .WithTrafficLightTimeSecond(40)
        //      .WithLanes(3)
        //      .WithLengthM(400)
        //      .WithSpeedLimit(60)
        //       .WithIncoming(10)
        //      .WithOutgoing(10)
        //      .Build();

        //  RoadEdge edge5 = new RoadEdge.Builder()
        //      .WithId(5)
        //      .WithNameGap("Street D-E")
        //      .WithSource(nodeD)
        //      .WithTarget(nodeE)
        //      .WithTrafficLightTimeSecond(15)
        //      .WithLanes(2)
        //      .WithLengthM(250)
        //      .WithSpeedLimit(50)
        //      .WithIncoming(10)
        //      .WithOutgoing(10)
        //      .Build();

        //  RoadEdge edge6 = new RoadEdge.Builder()
        //      .WithId(6)
        //      .WithNameGap("Street C-E")
        //      .WithSource(nodeC)
        //      .WithTarget(nodeE)
        //      .WithTrafficLightTimeSecond(15)
        //      .WithLanes(2)
        //      .WithLengthM(250)
        //      .WithSpeedLimit(50)
        //      .WithIncoming(10)
        //      .WithOutgoing(10)
        //      .Build();

        // RoadEdge edge7 = new RoadEdge.Builder()
        //  .WithId(7)
        //  .WithNameGap("Street B-E")
        //  .WithSource(nodeB)
        //  .WithTarget(nodeE)
        //  .WithTrafficLightTimeSecond(15)
        //  .WithLanes(2)
        //  .WithLengthM(250)
        //  .WithSpeedLimit(50)
        //  .WithIncoming(10)
        //  .WithOutgoing(10)
        //  .Build();

        //RoadEdge edge8 = new RoadEdge.Builder()
        //  .WithId(8)
        //  .WithNameGap("Street B-F")
        //  .WithSource(nodeB)
        //  .WithTarget(nodeF)
        //  .WithTrafficLightTimeSecond(15)
        //  .WithLanes(2)
        //  .WithLengthM(250)
        //  .WithSpeedLimit(50)
        //  .WithIncoming(20)
        //  .WithOutgoing(10)
        //  .Build();

        //  RoadEdge edge9 = new RoadEdge.Builder()
        //  .WithId(9)
        //  .WithNameGap("Street F-E")
        //  .WithSource(nodeF)
        //  .WithTarget(nodeE)
        //  .WithTrafficLightTimeSecond(15)
        //  .WithLanes(2)
        //  .WithLengthM(250)
        //  .WithSpeedLimit(50)
        //  .WithIncoming(10)
        //  .WithOutgoing(10)
        //  .Build();

        //  RoadEdge edge10 = new RoadEdge.Builder()
        //  .WithId(10)
        //  .WithNameGap("Street F-G")
        //  .WithSource(nodeF)
        //  .WithTarget(nodeG)
        //  .WithTrafficLightTimeSecond(15)
        //  .WithLanes(2)
        //  .WithLengthM(250)
        //  .WithSpeedLimit(50)
        //  .WithIncoming(10)
        //  .WithOutgoing(10)
        //  .Build();

        //  RoadEdge edge11 = new RoadEdge.Builder()
        // .WithId(11)
        // .WithNameGap("Street G-E")
        // .WithSource(nodeG)
        // .WithTarget(nodeE)
        // .WithTrafficLightTimeSecond(15)
        // .WithLanes(2)
        // .WithLengthM(250)
        // .WithSpeedLimit(50)
        // .WithIncoming(10)
        // .WithOutgoing(10)
        // .Build();

        RoadMap roadMap = new RoadMap.Builder("Моя карта дорог")
        .AddNode(nodeA)
        .AddNode(nodeB)
        .AddNode(nodeC)
        .AddNode(nodeD)
        .AddNode(nodeE)
        .AddEdge(edge1)
        .AddEdge(edge2)
        .AddEdge(edge3)
        .AddEdge(edge4)
        .AddEdge(edge5)
         .AddEdge(edge6)
         .AddEdge(edge7)
         .AddEdge(edge8)
        .Build();


        List<Tuple<RoadEdge, RoadEdge>> paths = RandomPathGenerator.GenerateRandomPaths(roadMap);
        List<DijkstraAlgorithm.ShortestPathResult> DijPathList = new List<DijkstraAlgorithm.ShortestPathResult>();//список всего, что вернула дейкстра
        int i = 0;
        foreach (var item in paths)
        {
            Console.WriteLine(item.Item1.NameGap + "\t" + item.Item2.NameGap);


            Console.WriteLine("Информация по пути " + i);
            i++;
            DijkstraAlgorithm dijkstra = new DijkstraAlgorithm();
            RoadNode startNode = item.Item1.Source;
            RoadNode targetNode = item.Item2.Target;
            DijkstraAlgorithm.ShortestPathResult result = dijkstra.FindShortestPath(roadMap, startNode, targetNode);
            DijPathList.Add(result);
            Console.WriteLine($"Длина пути: {result.Distance} метров");
            Console.WriteLine($"Время в пути: {result.Time} секунд");
            foreach (var node in result.PathEdge)
            {
                Console.WriteLine(node.NameGap);
            }
        }
        List<Car> cars = new List<Car>();
        int j = 0;
        foreach (var item in DijPathList)//создание машин
        {
            Car car = new Car(j, item.PathEdge);
            cars.Add(car);
            j++;
        }

        Console.WriteLine("количество машин:" + cars.Count);
        Simulation simulation = new Simulation(roadMap, 10, 10);
        foreach (var item in cars)//добавление их в симуляцию
        {
            simulation.AddCar(item);
        }
        List<SimulationState> simulationStates = simulation.RunSimulation();
        
        // Вывод результатов
        foreach (SimulationState state in simulationStates)
        {
            Console.WriteLine($"Итерация {state.Iteration}:");
            //foreach (CarState carState in state.CarStates)
            //{
            //    Console.WriteLine($"машина {carState.CarName} на дороге {carState.CurrentEdgeName}");
            //}
            
            foreach (KeyValuePair<string, int> additionalTime in state.AdditionalTimes)
            {
                Console.WriteLine($"Traffic congestion on edge {additionalTime.Key}. Increased travel time by {additionalTime.Value} seconds.");
            }

            foreach (KeyValuePair<string, double> edgeCongestion in state.EdgeCongestion)
            {
                Console.WriteLine($"дорога {edgeCongestion.Key} загруженность: {edgeCongestion.Value}");
            }

            Console.WriteLine();
        }
        Console.ReadKey();
    }
    //List<Tuple<RoadEdge, RoadEdge>> paths = RandomPathGenerator.GenerateRandomPaths(roadMap);
    //int i = 0;
    //foreach (var item in paths)
    //{
    //    //Console.WriteLine(item.Item1.NameGap + "\t" + item.Item2.NameGap);
    //    //Console.WriteLine(item.Item1.NameGap + "\t" + item.Item2.NameGap);


    //    Console.WriteLine("Информация по пути " + i);
    //    i++;

    //    DijkstraAlgorithmEdge dijkstra = new DijkstraAlgorithmEdge();

    //    // Находим кратчайший путь
    //    List<RoadEdge> shortestPath = dijkstra.FindShortestPath(roadMap.Nodes, roadMap.Edges, item.Item1.Source, item.Item1.Target);

    //    // Выводим кратчайший путь
    //    if (shortestPath != null)
    //    {
    //        Console.WriteLine("Shortest path:");
    //        foreach (RoadEdge edge in shortestPath)
    //        {
    //            Console.WriteLine($"{edge.NameGap} ({edge.Source.streetNames} -> {edge.Target.streetNames})");
    //        }
    //    }
    //    else
    //    {
    //        Console.WriteLine("No path found.");
    //    }
    //}


    //DijkstraAlgorithm dijkstra = new DijkstraAlgorithm();
    //RoadNode startNode = edge3.Target;
    //RoadNode targetNode = edge8.Source;
    //DijkstraAlgorithm.ShortestPathResult result = dijkstra.FindShortestPath(roadMap, startNode, targetNode);

    //Console.WriteLine($"Длина пути: {result.Distance} метров");
    //Console.WriteLine($"Время в пути: {result.Time} секунд");
    //foreach (var node in result.Path)
    //{
    //    Console.WriteLine(node.streetNames);
    //}
}
