using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAnalysis
{
    class WeatherMain
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("humidity")]
        public double Humidity { get; set; }

        internal APIWeather APIWeather
        {
            get => default;
            set
            {
            }
        }

        public ActivateWeatherAnalysis ActivateWeatherAnalysis
        {
            get => default;
            set
            {
            }
        }
    }
}
