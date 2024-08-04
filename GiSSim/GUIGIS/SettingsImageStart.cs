using GUIGIS.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIGIS
{
    internal class SettingsImageStart
    {
        public double X;
        public double Y;
        public SettingsImageStart()
        {
            X=0;
            Y=0;
        }
        public void SettingsImage(PictureBox pictureBox1, TrackBar trackBar1, Label Koord)
        {

            pictureBox1.Image = Resources.Ub;//выбор картинки

            // Устанавливаем максимальное значение трекбара
            trackBar1.Maximum = 10;
            trackBar1.Minimum = 1;
            // Устанавливаем начальное значение трекбара
            trackBar1.Value = 10;

            // Подписываемся на событие изменения значения трекбара
            trackBar1.ValueChanged += (sender, e) =>
            {
                // Получаем текущее значение трекбара
                int zoomValue = trackBar1.Value;

                // Изменяем масштаб изображения в зависимости от значения трекбара
                UpdateImageScale(pictureBox1, zoomValue);
            };
            // Подписываемся на событие MouseMove для отображения координат
            pictureBox1.MouseMove += (sender, e) =>
            {
                Point imagePoint = GetImageCoordinates(e.Location, pictureBox1);
                Koord.Text = $"X: {imagePoint.X}, Y: {imagePoint.Y}";
                X = imagePoint.X; Y = imagePoint.Y;
            };
        }
        // Метод для обновления масштаба изображения
        private void UpdateImageScale(PictureBox pictureBox, int zoomValue)
        {
            // Устанавливаем режим масштабирования изображения в PictureBoxSizeMode.Zoom
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            // Изменяем размеры PictureBox в соответствии с масштабом
            float zoom = (float)zoomValue / 10;
            pictureBox.Width = (int)(pictureBox.Image.Width * zoom);
            pictureBox.Height = (int)(pictureBox.Image.Height * zoom);
        }

        // Метод для преобразования координат мыши в координаты на изображении
        private Point GetImageCoordinates(Point mousePosition, PictureBox pictureBox)
        {
            float imageScaleX = (float)pictureBox.Image.Width / pictureBox.Width;
            float imageScaleY = (float)pictureBox.Image.Height / pictureBox.Height;
            int imageX = (int)(mousePosition.X * imageScaleX);
            int imageY = (int)(mousePosition.Y * imageScaleY);
            return new Point(imageX, imageY);
        }
    }
}
