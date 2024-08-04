using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAnalysis
{
    internal class HistoricalData
    {
        // Список записей исторических данных
        private List<HistoricalRecord> data;

        // Конструктор класса
        public HistoricalData()
        {
            // Инициализация списка
            data = new List<HistoricalRecord>();
        }

        internal KnowBase KnowBase
        {
            get => default;
            set
            {
            }
        }

        // Метод для добавления новой записи в исторические данные
        public void AddRecord(DateTime date, string weather, int traffic)
        {
            data.Add(new HistoricalRecord { Date = date, Weather = weather, Traffic = traffic });
        }

        // Метод для получения всех записей исторических данных
        public List<HistoricalRecord> GetAllRecords()
        {
            return data;
        }

        // Вспомогательный класс, представляющий отдельную запись исторических данных
        public class HistoricalRecord
        {
            public DateTime Date { get; set; }
            public string Weather { get; set; }
            public int Traffic { get; set; }
        }
    }
}
