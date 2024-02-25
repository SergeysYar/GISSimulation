using GiSSim;
using GUIGIS.Properties;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace GUIGIS
{
    public partial class Form1 : Form
    {

        GiSSim.GiSSim giSSim;
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

            pictureBox1.Image = Resources.Map;
            //pictureBox1.Dock = DockStyle.Fill;
            //pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;


            //panel1.AutoScrollMinSize = new Size(0, 0); // Устанавливаем минимальный размер для прокрутки


            // Устанавливаем максимальное значение трекбара
            trackBar1.Maximum = 10;

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
            //Track(trackBar1, pictureBox1);
            // Подписываемся на событие MouseMove для отображения координат
            pictureBox1.MouseMove += (sender, e) =>
            {
                Point imagePoint = GetImageCoordinates(e.Location, pictureBox1);
                Koord.Text = $"X: {imagePoint.X}, Y: {imagePoint.Y}";
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

        private void button1_Click_1(object sender, EventArgs e)//изменить масштаб
        {
            // Подписываемся на событие изменения значения трекбара
            trackBar1.ValueChanged += (sender, e) =>
            {
                // Получаем текущее значение трекбара
                int zoomValue = trackBar1.Value;

                // Изменяем масштаб изображения в зависимости от значения трекбара
                UpdateImageScale(pictureBox1, zoomValue);
            };
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            giSSim = new(toolStripTextBox1.Text);
        }

        private void button1_Click_2(object sender, EventArgs e)//добавление узла
        {
            giSSim.AddNode(NodeNameAddText.Text, Convert.ToDouble(NodeXAddText.Text), Convert.ToDouble(NodeYAddText.Text));
        }

        private void button4_Click(object sender, EventArgs e)//добавление ребра
        {
            giSSim.AddEdge(AddNameTextBoxEdge.Text, Convert.ToInt32(AddEdgeComboBoxNodes1.Text),
                Convert.ToInt32(AddEdgeComboBoxNodes2.Text), Convert.ToInt32(AddTrafficTimeTextBoxEdge.Text),
                Convert.ToInt32(AddLinesEdgeTextBox.Text), Convert.ToInt32(AddLenghtMTextBox.Text),
                Convert.ToInt32(AddSpeedLimitTextBox.Text), Convert.ToInt32(AddInComingEdgetextBox.Text), Convert.ToInt32(AddOutComingEdgetextBox.Text));
        }
    }
}