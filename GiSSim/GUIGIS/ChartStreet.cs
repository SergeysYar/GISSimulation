using GiSSim;
using ScottPlot;
using ScottPlot.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUIGIS
{
    internal class ChartStreet
    {
        public static void ChartSettings(FormsPlot formsPlot, RoadMap roadMap,ComboBox EdgesChartComboBox, int minutesPassed)//создание графика
        {
            // Очищаем предыдущие данные
            formsPlot.Plot.Clear();
            

            int selectedEdgeIndex = Convert.ToInt32(EdgesChartComboBox.Text);
            var workloads = roadMap.Edges[selectedEdgeIndex].WorkLoadsList;
            formsPlot.Plot.Axes.SetLimits(0, workloads.Count, 0, 1);
            formsPlot.Plot.Axes.Left.Label.Text = "Коофициент загруженности";

            ScottPlot.TickGenerators.NumericManual ticks = new();

            double[] ys = new double[workloads.Count];
            double[] xs = new double[workloads.Count];
            for (int i = 0; i < workloads.Count; i++)
            {
                // Начальное время 6:30
                DateTime startTime = new DateTime(1, 1, 1, 6, 30, 0);

                // Добавляем введенное количество минут
                DateTime newTime = startTime.AddMinutes(minutesPassed * i);
                
                ticks.AddMajor(i, newTime.ToString("HH:mm"));
                ys[i] = workloads[i];
                xs[i] = i;
            }
            formsPlot.Plot.Axes.Bottom.TickGenerator = ticks;
            formsPlot.Plot.Add.Scatter(xs, ys);
            formsPlot.Refresh();
        }
    }
}
