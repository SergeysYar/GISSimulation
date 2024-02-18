using GiSSim;
using GUIGIS.Properties;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace GUIGIS
{
    public partial class Form1 : Form
    {

        GiSSim.GiSSim giSSim = new("Моя карта");
        RoadMap roadMap;
        //PictureBox pictureBox = new PictureBox();
        public Form1()
        {
            InitializeComponent();
            SettingsImage();//настройка изображения
        }
        private void Настройки_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                giSSim.SaveRoadMap(filePath);
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                giSSim.LoadRoadMap(filePath);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void SettingsImage()
        {
            Panel panel1 = new Panel();
            panel1.AutoScroll = true;
            panel1.AutoScrollMinSize = new Size(0, 0); // Может быть установлен на размер контента внутри Panel
            panel1.Dock = DockStyle.Fill; // Или используйте Anchor для привязки к краям формы

            splitContainer1.Panel1.Controls.Add(panel1);
            panel1.AutoScroll = true; // Включаем автоматическую прокрутку

            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Resources.Map;
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            panel1.Controls.Add(pictureBox);

            panel1.Dock = DockStyle.Fill;

            //panel1.AutoScrollMinSize = new Size(0, 0); // Устанавливаем минимальный размер для прокрутки


            trackBar1.Minimum = 1;
            trackBar1.Maximum = 10;
            trackBar1.Value = 5; // Начальное значение масштаба
            //trackBar1.Dock = DockStyle.Top;
            //Track(trackBar1, pictureBox);
            // Подписываемся на событие MouseMove для отображения координат
            pictureBox.MouseMove += (sender, e) =>
            {
                Point imagePoint = GetImageCoordinates(e.Location, pictureBox);
                Koord.Text = $"X: {imagePoint.X}, Y: {imagePoint.Y}";
            };


            panel1.AutoScroll = true; // Включаем автоматическую прокрутку
        }
        static void Track(System.Windows.Forms.TrackBar trackBar1, PictureBox pictureBox)
        {
            trackBar1.ValueChanged += (sender, e) =>
            {

                float zoom = (float)trackBar1.Value / 5;
                pictureBox.Width = (int)(pictureBox.Image.Width * zoom);
                pictureBox.Height = (int)(pictureBox.Image.Height * zoom);
                pictureBox.Invalidate(); // Перерисовываем PictureBox при изменении масштаба
            };

        }

        // Метод для обновления размеров PictureBox в соответствии с масштабом
        private void UpdatePictureBoxSize(PictureBox pictureBox, int scale)
        {
            float zoom = (float)scale / 5;
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

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}