using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiSSim
{
    public class Simulation
    {
        private RoadMap RoadMap;
        private List<Car> cars;
        private int iterationStep;
        private int minute;
        private List<SimulationState> simulationStates;

        public Simulation(RoadMap roadMap, int iterationStep, int minute)
        {
            RoadMap = roadMap;
            this.iterationStep = iterationStep;
            this.minute = minute;
            this.cars = new List<Car>();
            this.simulationStates = new List<SimulationState>();
        }

        public void AddCar(Car car)
        {
            cars.Add(car);
        }

        public List<SimulationState> RunSimulation()
        {
            Dictionary<string, int> CarCountsByEdge = new Dictionary<string, int>();//количество машин
            simulationStates.Clear();

            for (int i = 0; i < iterationStep; i++)
            {
                SimulationState state = new SimulationState();
                state.Iteration = i + 1;

                foreach (Car car in cars)
                {
                    RoadEdge currentEdge = car.GetCurrentEdge();
                    state.CarStates.Add(new CarState(car.Name, currentEdge.NameGap));

                   
                        double congestionPercentage = (double)currentEdge.Incoming / currentEdge.Lanes;
                        int additionalTime = (int)(currentEdge.TraficLightTimeSecond * congestionPercentage);
                        if (!state.AdditionalTimes.ContainsKey(currentEdge.NameGap))
                        {
                            state.AdditionalTimes.Add(currentEdge.NameGap, additionalTime);
                        }
                        else
                        {
                            // Ключ уже существует, обновим значение
                            state.AdditionalTimes[currentEdge.NameGap] = additionalTime;
                        }


                    // Сохранение количества машин на текущем ребре
                    if (!state.CarCountsByEdge.ContainsKey(currentEdge.NameGap))
                    {
                        state.CarCountsByEdge.Add(currentEdge.NameGap, 1);
                    }
                    else
                    {
                        state.CarCountsByEdge[currentEdge.NameGap]++;
                    }
                    CarCountsByEdge = state.CarCountsByEdge;
                    car.TimeOnCurrentEdge += minute;
                    // Увеличение времени нахождения машины на данной улице в зависимости от коэффициента загруженности
                    int additionalTimeOnEdge = (int)(congestionPercentage * car.TimeOnCurrentEdge);
                    car.TimeOnCurrentEdge += additionalTimeOnEdge;

                    car.MoveToNextEdge();
                }

                // Вычислить перегрузку
                foreach (RoadEdge edge in RoadMap.Edges)
                {
                    double bandWidth = 2.5;//ширина полосы
                    double trafficDensity = 1000/edge.SpeedLimit / 2;//плотность движения
                    double bandwidthOneLane = bandWidth * trafficDensity * edge.SpeedLimit;//пропускная способность одной полосы
                    int numberCars;
                    if (CarCountsByEdge.ContainsKey(edge.NameGap))//проверка на наличие дороги
                    {
                        numberCars = CarCountsByEdge[edge.NameGap];//количество мащин
                        double trafficCongestionFactor = (double)numberCars / (edge.Lanes * bandwidthOneLane);//расчёт коэфициента загруженности дороги
                        state.EdgeCongestion.Add(edge.NameGap, trafficCongestionFactor);
                    }

                }

                simulationStates.Add(state);
            }

            return simulationStates;
        }
    }

    public class SimulationState
    {
        public int Iteration { get; set; }
        public List<CarState> CarStates { get; }
        public Dictionary<string, int> CarCountsByEdge { get; }//количество машин
        public Dictionary<string, int> AdditionalTimes { get; }
        public Dictionary<string, double> EdgeCongestion { get; }

        public SimulationState()
        {
            CarStates = new List<CarState>();
            CarCountsByEdge = new Dictionary<string, int>();//иницилизаци количество машин
            AdditionalTimes = new Dictionary<string, int>();
            EdgeCongestion = new Dictionary<string, double>();
        }
    }


    public class CarState
    {
        public int CarName { get; }
        public string CurrentEdgeName { get; }

        public CarState(int carName, string currentEdgeName)
        {
            CarName = carName;
            CurrentEdgeName = currentEdgeName;
        }
    }

}
