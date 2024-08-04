using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms.DataVisualization.Charting;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using ScottPlot.WinForms;
using DocumentFormat.OpenXml.Math;
using GiSSim;

namespace GUIGIS
{
    internal class ChartLoadInExcel
    {
        private static void SetEPPlusLicense()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // или
            // ExcelPackage.LicenseContext = LicenseContext.Commercial;
        }
        public static void ExcelSave(RoadMap roadMap, ComboBox EdgesChartComboBox)
        {
            // Установить контекст лицензии EPPlus
            SetEPPlusLicense();

            // Инициализация диалогового окна сохранения файла
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel Files|*.xlsx|All files (*.*)|*.*";
            saveFileDialog1.Title = "Сохранить файл Excel";

            // Показываем диалоговое окно сохранения файла
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Создаем новый файл Excel
                FileInfo newFile = new FileInfo(saveFileDialog1.FileName);

                using (ExcelPackage excelPackage = new ExcelPackage(newFile))
                {
                    string worksheetName = "Данные";

                    // Проверяем, существует ли лист с таким именем
                    int worksheetCount = 1;
                    while (excelPackage.Workbook.Worksheets.Any(ws => ws.Name == worksheetName))
                    {
                        worksheetName = "Данные" + worksheetCount;
                        worksheetCount++;
                    }
                    // Добавляем лист в файл Excel
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(worksheetName);

                    // Получаем индекс выбранного элемента ComboBox
                    int selectedEdgeIndex = Convert.ToInt32(EdgesChartComboBox.Text);
                    var workloads = roadMap.Edges[selectedEdgeIndex].WorkLoadsList;

                    // Записываем данные в Excel
                    for (int i = 0; i < workloads.Count; i++)
                    {
                        worksheet.Cells[i + 2, 1].Value = workloads[i];
                    }

                    // Добавляем диаграмму на лист Excel
                    ExcelChart chart = worksheet.Drawings.AddChart("Диаграмма", eChartType.ColumnClustered);
                    chart.SetSize(300, 300);
                    chart.SetPosition(100, 100);

                    // Устанавливаем диапазон данных для диаграммы
                    var range = worksheet.Cells[2, 1, workloads.Count + 1, 1];
                    var series = chart.Series.Add(range);
                    series.HeaderAddress = worksheet.Cells[1, 1];

                    // Устанавливаем тип диаграммы (например, столбчатую)
                    chart.Style = eChartStyle.Style2;
                    excelPackage.Save();
                    MessageBox.Show("Сохранение завершено");
                }
            }
        }
    }
}
