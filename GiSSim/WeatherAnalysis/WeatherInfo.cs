using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeatherAnalysis
{
    class WeatherInfo
    {
        [JsonProperty("main")]
        public WeatherMain Main { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonIgnore]
        public double Temperature => Main?.Temp ?? 0;

        [JsonIgnore]
        public double Humidity => Main?.Humidity ?? 0;

        [JsonIgnore]
        public double WindSpeed => Wind?.Speed ?? 0;
    }
}
