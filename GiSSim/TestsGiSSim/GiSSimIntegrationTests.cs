using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiSSim;

namespace TestsGiSSim
{
    public class GiSSimIntegrationTests
    {
        [Test]
        public void TestFullWorkflow()
        {
            try
            {
                Console.WriteLine("Starting TestFullWorkflow");

                // Шаг 1: Создание карты
                var sim = new GiSSim.GiSSim("TestMap");
                Console.WriteLine("Created GiSSim instance.");

                // Шаг 2: Добавление узлов
                sim.AddNode("Node1", 0.0, 0.0);
                sim.AddNode("Node2", 1.0, 1.0);
                sim.AddNode("Node3", 2.0, 2.0);
                Console.WriteLine("Added nodes.");

                // Проверка, что узлы добавлены корректно
                Assert.AreEqual(3, sim.roadMap.Nodes.Count);
                Assert.AreEqual("Node1", sim.roadMap.Nodes[0].streetNames);
                Assert.AreEqual("Node2", sim.roadMap.Nodes[1].streetNames);
                Assert.AreEqual("Node3", sim.roadMap.Nodes[2].streetNames);

                // Шаг 3: Добавление ребер
                sim.AddEdge("Edge1", 0, 1, 30, 2, 100, 60, 10, 10);
                sim.AddEdge("Edge2", 1, 2, 30, 2, 100, 60, 10, 10);
                Console.WriteLine("Added edges.");

                // Проверка, что ребра добавлены корректно
                Assert.AreEqual(2, sim.roadMap.Edges.Count);
                Assert.AreEqual("Edge1", sim.roadMap.Edges[0].NameGap);
                Assert.AreEqual("Edge2", sim.roadMap.Edges[1].NameGap);

                // Шаг 4: Сохранение карты в файл
                string filename = "test_full_workflow_roadmap.json";
                sim.SaveRoadMap(filename);
                Console.WriteLine("Saved roadmap to file.");
                Assert.IsTrue(File.Exists(filename), "File was not saved.");

                // Шаг 5: Загрузка карты из файла в новый экземпляр GiSSim
                var newSim = new GiSSim.GiSSim("TestMap");
                newSim.LoadRoadMap(filename);
                Console.WriteLine("Loaded roadmap from file.");

                // Проверка, что карта загружена корректно
                Assert.AreEqual(3, newSim.roadMap.Nodes.Count);
                Assert.AreEqual("Node1", newSim.roadMap.Nodes[0].streetNames);
                Assert.AreEqual("Node2", newSim.roadMap.Nodes[1].streetNames);
                Assert.AreEqual("Node3", newSim.roadMap.Nodes[2].streetNames);
                Assert.AreEqual(2, newSim.roadMap.Edges.Count);
                Assert.AreEqual("Edge1", newSim.roadMap.Edges[0].NameGap);
                Assert.AreEqual("Edge2", newSim.roadMap.Edges[1].NameGap);

                // Шаг 6: Запуск симуляции
                Console.WriteLine("Starting simulation.");
                var roadMap = newSim.StartSimulation(10, 10);
                Console.WriteLine("Simulation completed.");

                // Проверка, что симуляция прошла корректно
                Assert.IsNotNull(roadMap);
                Assert.AreEqual(2, roadMap.Edges.Count);
                Assert.IsTrue(roadMap.Edges[0].WorkLoadsList.Count > 0);
                Assert.IsTrue(roadMap.Edges[1].WorkLoadsList.Count > 0);

                // Чистка: Удаление созданного файла
                File.Delete(filename);
                Console.WriteLine("Test completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Test failed with exception: {ex.Message}");
                throw;
            }
        }
    }
}
