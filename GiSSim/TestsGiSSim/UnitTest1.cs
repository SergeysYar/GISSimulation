using GiSSim;

namespace TestsGiSSim
{
    public class Tests
    {
        
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestAddNode()
        {
            GiSSim.GiSSim giSSim = new GiSSim.GiSSim("TestMap");
            giSSim.AddNode("Node1", 1.0, 2.0);
            Assert.AreEqual(1, giSSim.roadMap.Nodes.Count);
            Assert.AreEqual("Node1", giSSim.roadMap.Nodes[0].streetNames);
            Assert.AreEqual(1.0, giSSim.roadMap.Nodes[0].Coordinates.X);
            Assert.AreEqual(2.0, giSSim.roadMap.Nodes[0].Coordinates.Y);
        }

        [Test]
        public void TestRemoveNode()
        {
            GiSSim.GiSSim giSSim = new GiSSim.GiSSim("TestMap");
            var node = new RoadNode(0, "Node1", new Vector2D(1.0, 2.0));
            giSSim.roadMap.Nodes.Add(node);
            giSSim.RemoveNode(node);
            Assert.AreEqual(0, giSSim.roadMap.Nodes.Count);
        }

        [Test]
        public void TestAddEdge()
        {
            GiSSim.GiSSim giSSim = new GiSSim.GiSSim("TestMap");
            giSSim.AddNode("Node1", 1.0, 2.0);
            giSSim.AddNode("Node2", 3.0, 4.0);
            giSSim.AddEdge("Edge1", 0, 1, 30, 2, 100, 60, 10, 10);

            Assert.AreEqual(1, giSSim.roadMap.Edges.Count);
            var edge = giSSim.roadMap.Edges[0];
            Assert.AreEqual("Edge1", edge.NameGap);
            Assert.AreEqual(30, edge.TraficLightTimeSecond);
            Assert.AreEqual(2, edge.Lanes);
            Assert.AreEqual(100, edge.LengthM);
            Assert.AreEqual(60, edge.SpeedLimit);
            Assert.AreEqual(10, edge.Incoming);
            Assert.AreEqual(10, edge.Outgoing);
            Assert.AreEqual(giSSim.roadMap.Nodes[0], edge.Source);
            Assert.AreEqual(giSSim.roadMap.Nodes[1], edge.Target);
        }

        [Test]
        public void TestRemoveEdge()
        {
            GiSSim.GiSSim giSSim = new GiSSim.GiSSim("TestMap");
            giSSim.AddNode("Node1", 1.0, 2.0);
            giSSim.AddNode("Node2", 3.0, 4.0);
            giSSim.AddEdge("Edge1", 0, 1, 30, 2, 100, 60, 10, 10);

            var edge = giSSim.roadMap.Edges[0];
            giSSim.RemoveEdge(edge);
            Assert.AreEqual(0, giSSim.roadMap.Edges.Count);
        }

        [Test]
        public void TestSaveLoadRoadMap()
        {
            GiSSim.GiSSim giSSim = new GiSSim.GiSSim("TestMap");
            giSSim.AddNode("Node1", 1.0, 2.0);
            giSSim.AddEdge("Edge1", 0, 0, 30, 2, 100, 60, 10, 10);
            string filename = "test_roadmap.json";

            giSSim.SaveRoadMap(filename);
            var loadedGiSSim = new GiSSim.GiSSim("LoadedMap");
            loadedGiSSim.LoadRoadMap(filename);

            Assert.AreEqual(giSSim.roadMap.Nodes.Count, loadedGiSSim.roadMap.Nodes.Count);
            Assert.AreEqual(giSSim.roadMap.Edges.Count, loadedGiSSim.roadMap.Edges.Count);
            Assert.AreEqual(giSSim.roadMap.Nodes[0].Id, loadedGiSSim.roadMap.Nodes[0].Id);
            Assert.AreEqual(giSSim.roadMap.Edges[0].Id, loadedGiSSim.roadMap.Edges[0].Id);
        }

        [Test]
        public void TestStartSimulation()
        {
            GiSSim.GiSSim giSSim = new GiSSim.GiSSim("TestMap");
            giSSim.AddNode("Node1", 1.0, 2.0);
            giSSim.AddNode("Node2", 3.0, 4.0);
            giSSim.AddEdge("Edge1", 0, 1, 30, 2, 100, 60, 10, 10);

            var resultMap = giSSim.StartSimulation(10, 60);

            Assert.NotNull(resultMap);
            Assert.AreEqual(2, resultMap.Nodes.Count);
            Assert.AreEqual(1, resultMap.Edges.Count);
        }
    }
}