using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WeatherAnalysis;

class Program
{
    static async Task Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Не указана дата. Пожалуйста, введите дату в формате ГГГГ-ММ-ДД (например, 2024-04-01):");
            string date = Console.ReadLine();
            string city = Console.ReadLine();
            await APIWeather.GetWeatherInfoFromAPI(date, city);
            Console.WriteLine(ActivateWeatherAnalysis.GetAPIWeather(date, city).ToString());
        }
        else
        {
            // await GetWeatherInfoFromAPI(args[0]);
        }
    }
}






