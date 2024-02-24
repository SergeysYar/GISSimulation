using GiSSim;
using GUIGIS.Properties;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace GUIGIS
{
    public partial class Form1 : Form
    {

        GiSSim.GiSSim giSSim = new("��� �����");
        RoadMap roadMap;
        //PictureBox pictureBox = new PictureBox();
        public Form1()
        {
            InitializeComponent();
            SettingsImage();//��������� �����������
        }
        private void ���������_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                giSSim.SaveRoadMap(filePath);
            }
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
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
            panel1.AutoScrollMinSize = new Size(0, 0); // ����� ���� ���������� �� ������ �������� ������ Panel
            panel1.Dock = DockStyle.Fill; // ��� ����������� Anchor ��� �������� � ����� �����

            splitContainer1.Panel1.Controls.Add(panel1);
            panel1.AutoScroll = true; // �������� �������������� ���������

            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Resources.Map;
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            panel1.Controls.Add(pictureBox);

            panel1.Dock = DockStyle.Fill;

            //panel1.AutoScrollMinSize = new Size(0, 0); // ������������� ����������� ������ ��� ���������


            trackBar1.Minimum = 1;
            trackBar1.Maximum = 10;
            trackBar1.Value = 5; // ��������� �������� ��������
            //trackBar1.Dock = DockStyle.Top;
            //Track(trackBar1, pictureBox);
            // ������������� �� ������� MouseMove ��� ����������� ���������
            pictureBox.MouseMove += (sender, e) =>
            {
                Point imagePoint = GetImageCoordinates(e.Location, pictureBox);
                Koord.Text = $"X: {imagePoint.X}, Y: {imagePoint.Y}";
            };


            panel1.AutoScroll = true; // �������� �������������� ���������
        }
        static void Track(System.Windows.Forms.TrackBar trackBar1, PictureBox pictureBox)
        {
            trackBar1.ValueChanged += (sender, e) =>
            {

                float zoom = (float)trackBar1.Value / 5;
                pictureBox.Width = (int)(pictureBox.Image.Width * zoom);
                pictureBox.Height = (int)(pictureBox.Image.Height * zoom);
                pictureBox.Invalidate(); // �������������� PictureBox ��� ��������� ��������
            };

        }

        // ����� ��� ���������� �������� PictureBox � ������������ � ���������
        private void UpdatePictureBoxSize(PictureBox pictureBox, int scale)
        {
            float zoom = (float)scale / 5;
            pictureBox.Width = (int)(pictureBox.Image.Width * zoom);
            pictureBox.Height = (int)(pictureBox.Image.Height * zoom);
        }

        // ����� ��� �������������� ��������� ���� � ���������� �� �����������
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