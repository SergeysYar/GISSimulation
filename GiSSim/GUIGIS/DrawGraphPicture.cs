using GiSSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GUIGIS
{
    public class DrawGraphPicture
    {
        internal ChartStreet ChartStreet
        {
            get => default;
            set
            {
            }
        }

        internal SettingsImageStart SettingsImageStart
        {
            get => default;
            set
            {
            }
        }

        public static void DrawGraph(PictureBox pictureBox, float zoom, int iteration, RoadMap roadMap, Label currentValue, DataGridView datagrid)//отриосвка графа
        {
            datagrid.Rows.Clear();
            datagrid.Columns.Add("1", "Итеррация");
            datagrid.Columns.Add("2", "Улица");
            datagrid.Columns.Add("3", "Загруженность");

            double sumWorkLoad = 0;
            // Создаем объект Graphics из PictureBox
            using (Graphics graphics = pictureBox.CreateGraphics())
            {
                // Предполагается, что координаты точек уже установлены в каждом узле (RoadNode)
                foreach (var edge in roadMap.Edges)
                {
                    // Получаем координаты начальной и конечной точек ребра
                    Point startPoint = ScalePoint(edge.Source.Coordinates, zoom);
                    Point endPoint = ScalePoint(edge.Target.Coordinates, zoom);
                    sumWorkLoad += edge.WorkLoadsList[iteration];
                    if (edge.WorkLoadsList[iteration] < 0.01)
                    {
                        // Рисуем линию между начальной и конечной точками
                        graphics.DrawLine(new Pen(Color.Green, 5), startPoint, endPoint);
                    }
                    else if (edge.WorkLoadsList[iteration] < 0.1)
                    {
                        // Рисуем линию между начальной и конечной точками
                        graphics.DrawLine(new Pen(Color.Yellow, 5), startPoint, endPoint);
                    }
                    else
                    {
                        
                        // Рисуем линию между начальной и конечной точками
                        graphics.DrawLine(new Pen(Color.Red, 5), startPoint, endPoint);
                        AddDataGrid(datagrid, edge.NameGap, edge.WorkLoadsList[iteration], iteration);
                    }


                    // Выводим название ребра в середине линии
                    Point labelPosition = new((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
                    graphics.DrawString(edge.NameGap, new Font("Arial", 8), Brushes.Black, labelPosition);
                }
                sumWorkLoad= Math.Round(sumWorkLoad / roadMap.Edges.Count, 2);
                currentValue.Text= "Средний коэффициент загруженности: " + sumWorkLoad.ToString();
            }
        }
        public static void DrawPicture(PictureBox pictureBox, float zoom, RoadMap roadMap)
        {
            // Создаем объект Graphics из PictureBox
            using (Graphics graphics = pictureBox.CreateGraphics())
            {
                // Предполагается, что координаты точек уже установлены в каждом узле (RoadNode)
                foreach (var node in roadMap.Nodes)
                {
                    Point coordinate = ScalePoint(node.Coordinates, zoom);
                    // Радиус точки
                    int radius = 3;
                    // Цвет точки
                    Brush brush = Brushes.Red;
                    graphics.FillEllipse(brush,coordinate.X-radius, coordinate.Y-radius,2*radius,2*radius);
                    // Подписываем точку
                    string label = node.streetNames; // Ваша подпись
                    Font font = new Font("Arial", 10); // Шрифт подписи
                    Brush textBrush = Brushes.Red; // Цвет текста
                    graphics.DrawString(label, font, textBrush, coordinate.X + 5, coordinate.Y - 10); // Позиция текста относительно точки
                }
            }
        }
        private static Point ScalePoint(Vector2D Coordinates, float zoom)//отрисовка координат точек 
        {
            return new Point((int)(Coordinates.X * zoom), (int)(Coordinates.Y * zoom));
        }
        private static void AddDataGrid (DataGridView dataGridView, string name, double congestion, int iteration)
        {

            dataGridView.Rows.Add(iteration, name, Math.Round(congestion, 2).ToString());
        }
    }
}
