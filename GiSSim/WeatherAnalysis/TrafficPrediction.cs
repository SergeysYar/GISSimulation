using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAnalysis
{
    internal class TrafficPrediction
    {
        // Свойство для значения прогноза транспортного потока
        public double TrafficForecast { get; set; }

        // Конструктор класса
        public TrafficPrediction(double trafficForecast)
        {
            TrafficForecast = trafficForecast;
        }

        // Метод для вывода информации о прогнозе транспортного потока
        public void DisplayTrafficForecast()
        {
            Console.WriteLine($"Прогноз транспортного потока: {TrafficForecast}");
        }
    }
}
