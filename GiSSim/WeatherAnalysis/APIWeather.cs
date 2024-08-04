using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAnalysis
{
    internal class APIWeather
    {
        static double result;

        internal HistoricalData HistoricalData
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

        public static double GetWetherAPI(string date, string city)
        {
            GetWeatherInfoFromAPI(date, city);
            return result;
        }
        public static async Task GetWeatherInfoFromAPI(string date, string city)
        {
            string apiKey = "c0c62700b7565dd2e7c4f5d6b5263e53"; // Ваш API ключ от OpenWeatherMap
            //string city = "Moscow"; // Название города, для которого получаем прогноз

            string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric&dt={date}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    WeatherInfo weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(json);

                    // Загружаем базу знаний из JSON файла или другого источника
                    string knowledgeBaseJson = KnowBase.knowledgeBaseJson;

                    // Десериализуем базу знаний из JSON
                    JObject knowledgeBase = JObject.Parse(knowledgeBaseJson);

                    // Определяем изменение загруженности дорог на основе данных о погоде
                    string trafficChange = DetermineTrafficChange(weatherInfo, knowledgeBase);

                    result = Convert.ToDouble(trafficChange);
                    // Выводим результат
                }
                else
                {
                    throw new Exception($"Ошибка при получении данных о погоде: {response.StatusCode}");
                }
            }
        }
        static string DetermineTrafficChange(WeatherInfo weatherInfo, JObject knowledgeBase)
        {
            string temperature = GetParameterCategory(weatherInfo.Temperature, "температура", knowledgeBase);
            string humidity = GetParameterCategory(weatherInfo.Humidity, "влажность", knowledgeBase);
            string windSpeed = GetParameterCategory(weatherInfo.WindSpeed, "скорость_ветра", knowledgeBase);

            // Находим соответствующее изменение загруженности в базе знаний
            string trafficChange = FindTrafficChange(temperature, humidity, windSpeed, knowledgeBase);

            return trafficChange;
        }

        static string GetParameterCategory(double value, string parameter, JObject knowledgeBase)
        {
            JArray categories = (JArray)knowledgeBase["погодные_условия"];
            foreach (JObject category in categories)
            {
                string parOut = parameter;
                if (parameter == "температура")
                {
                    if (value < 5)
                        parOut = "низкая";
                    else if (value > 25)
                        parOut = "высокая";
                    else
                        parOut = "средняя";
                }
                else if (parameter == "влажность")
                {
                    if (value < 30)
                        parOut = "низкая";
                    else if (value > 70)
                        parOut = "высокая";
                    else
                        parOut = "средняя";
                }
                else if (parameter == "скорость_ветра")
                {
                    if (value < 5)
                        parOut = "низкая";
                    else if (value > 10)
                        parOut = "высокая";
                    else
                        parOut = "средняя";
                }
                if (category.Value<string>(parameter) == parOut)
                {
                    return category.Value<string>(parameter);
                }
            }
            throw new Exception($"Категория {parameter} не найдена в базе знаний.");
        }

        public static string FindTrafficChange(string temperature, string humidity, string windSpeed, JObject knowledgeBase)
        {
            JArray categories = (JArray)knowledgeBase["погодные_условия"];
            foreach (JObject category in categories)
            {
                if (category.Value<string>("температура") == temperature &&
                    category.Value<string>("влажность") == humidity &&
                    category.Value<string>("скорость_ветра") == windSpeed)
                {
                    return category.Value<string>("изменение_загруженности");
                }
            }
            throw new Exception($"Информация об изменении загруженности не найдена в базе знаний.");
        }
    }
}

