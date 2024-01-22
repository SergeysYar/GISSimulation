﻿using System;
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
        private List<SimulationState> simulationStates;

        public Simulation(RoadMap roadMap, int iterationStep)
        {
            RoadMap = roadMap;
            this.iterationStep = iterationStep;
            this.cars = new List<Car>();
            this.simulationStates = new List<SimulationState>();
        }

        public void AddCar(Car car)
        {
            cars.Add(car);
        }

        public List<SimulationState> RunSimulation()
        {
            simulationStates.Clear();

            for (int i = 0; i < iterationStep; i++)
            {
                SimulationState state = new SimulationState();
                state.Iteration = i + 1;

                foreach (Car car in cars)
                {
                    RoadEdge currentEdge = car.GetCurrentEdge();
                    state.CarStates.Add(new CarState(car.Name, currentEdge.NameGap));

                    //Проверьте, не превышает ли количество автомобилей на текущем ребре его пропускную способность
                    //if (currentEdge.Incoming > currentEdge.Lanes)
                    //{
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

                    //}

                    car.MoveToNextEdge();
                }

                // Вычислить перегрузку
                foreach (RoadEdge edge in RoadMap.Edges)
                {
                    double congestionPercentage = (double)edge.Incoming / edge.Lanes;
                    state.EdgeCongestion.Add(edge.NameGap, congestionPercentage);
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
        public Dictionary<string, int> AdditionalTimes { get; }
        public Dictionary<string, double> EdgeCongestion { get; }

        public SimulationState()
        {
            CarStates = new List<CarState>();
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
