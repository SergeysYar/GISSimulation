using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAnalysis
{
    internal class WeatherForecast
    {
        // Свойство для температуры
        public int Temperature { get; set; }

        // Свойство для типа погоды
        public string WeatherType { get; set; }

        // Свойство для даты прогноза
        public DateTime ForecastDate { get; set; }

        internal WeatherForecastCorrectionModule WeatherForecastCorrectionModule
        {
            get => default;
            set
            {
            }
        }

        // Конструктор класса
        public WeatherForecast(int temperature, string weatherType, DateTime forecastDate)
        {
            Temperature = temperature;
            WeatherType = weatherType;
            ForecastDate = forecastDate;
        }

        // Метод для вывода информации о прогнозе погоды
        public void DisplayForecast()
        {
            Console.WriteLine($"Прогноз погоды на {ForecastDate}:");
            Console.WriteLine($"Температура: {Temperature}°C");
            Console.WriteLine($"Тип погоды: {WeatherType}");
        }
    }
}
