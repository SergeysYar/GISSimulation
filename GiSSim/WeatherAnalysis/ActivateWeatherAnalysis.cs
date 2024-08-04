using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAnalysis
{
    public class ActivateWeatherAnalysis
    {
        internal HistoricalData HistoricalData
        {
            get => default;
            set
            {
            }
        }

        internal WeatherForecast WeatherForecast
        {
            get => default;
            set
            {
            }
        }

        public static double  GetAPIWeather(string date, string city)
        {
            return APIWeather.GetWetherAPI(date, city);
        }
        public static double GetManualWeather(string temperature, string humidity, string windSpeed)
        {
            JObject knowledgeBase = JObject.Parse(KnowBase.knowledgeBaseJson);
            return Convert.ToDouble(APIWeather.FindTrafficChange(temperature, humidity, windSpeed, knowledgeBase));
        }
    }
}
