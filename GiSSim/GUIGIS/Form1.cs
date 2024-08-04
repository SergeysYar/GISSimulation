using GiSSim;
using GUIGIS.Properties;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.DataVisualization;
using Microsoft.VisualBasic;
using System.Windows.Forms.DataVisualization.Charting;


namespace GUIGIS
{
    public partial class Form1 : Form
    {
        SettingsImageStart settings = new();
        public static GiSSim.GiSSim giSSim { get; set; }
        public static double indexWeather { get; set; }
        RoadMap roadMap;
        bool launchIndicator = false;
        public Form1()
        {
            InitializeComponent();
            settings.SettingsImage(pictureBox1, trackBar1, Koord);//��������� �����������
            PictureBoxClic();//������� �� �����
            TurningElements();//���������� ��������
            dataGridView1.AllowUserToAddRows = false;
            //this.MouseWheel += Form1_MouseWheel;

        }
        private void TurningElements()//���������� ���������
        {
            button9.Enabled = false;
            button11.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }
        private void ���������_Click(object sender, EventArgs e)
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
            try
            {
                giSSim = new("");
                OpenFileDialog openFileDialog = new();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    giSSim.LoadRoadMap(filePath);
                }
                foreach (var item in giSSim.roadMap.Nodes)
                {
                    UpdateNodeIndexComboBox.Items.Add(item.Id);
                    UpdateEdgeNode1TextBox.Items.Add(item.Id);
                    UpdateEdgeNode2TextBox.Items.Add(item.Id);
                    AddEdgeComboBoxNodes1.Items.Add(item.Id);
                    AddEdgeComboBoxNodes2.Items.Add(item.Id);
                }
                foreach (var item in giSSim.roadMap.Edges)
                {
                    UpdateEdgeIndexComboBox.Items.Add(item.Id);
                    EdgesChartComboBox.Items.Add(item.Id);
                }
                //����� �����
                int zoomValue = trackBar1.Value;
                float zoom = (float)zoomValue / 10;
                DrawGraphPicture.DrawPicture(pictureBox1, zoom, giSSim.roadMap);
                button2.Enabled = true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)//���������� ��������
        {

            int zoomValue = trackBar1.Value;
            float zoom = (float)zoomValue / 10;
            DrawGraphPicture.DrawGraph(pictureBox1, zoom, Convert.ToInt32(numericUpDown1.Value), roadMap, label3, dataGridView1);
            DrawGraphPicture.DrawPicture(pictureBox1, zoom, roadMap);
        }
        private void button2_Click(object sender, EventArgs e)//������ ���������
        {
            LongTimeStartSimulation();
            button3.Enabled = true;
            button9.Enabled = true;
            launchIndicator = true;//����������� �������
        }
        private async void LongTimeStartSimulation()
        {
            // ���������� ������������, ��� �������� ��������
            MessageBox.Show("����������� ��������...");

            // ��������� ������ �������� � ����������� ������
            await Task.Run(() =>
            {
                roadMap = giSSim.StartSimulation(Convert.ToInt32(ItearationTextBox.Text), Convert.ToInt32(TimeTextBox.Text));
            });

            // ���������� ������������, ��� �������� ���������
            MessageBox.Show("�������� ���������.");
        }

        private void button1_Click_1(object sender, EventArgs e)//���������� ����
        {
            giSSim.AddNode(NodeNameAddText.Text, Convert.ToDouble(NodeXAddText.Text), Convert.ToDouble(NodeYAddText.Text));
            AddEdgeComboBoxNodes1.Items.Add(NodeNameAddText.Text);
            AddEdgeComboBoxNodes2.Items.Add(NodeNameAddText.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)//���������� �����
        {
            giSSim.AddEdge(AddNameTextBoxEdge.Text, Convert.ToInt32(AddEdgeComboBoxNodes1.Text),
                Convert.ToInt32(AddEdgeComboBoxNodes2.Text), Convert.ToInt32(AddTrafficTimeTextBoxEdge.Text),
                Convert.ToInt32(AddLinesEdgeTextBox.Text), Convert.ToInt32(AddLenghtMTextBox.Text),
                Convert.ToInt32(AddSpeedLimitTextBox.Text), Convert.ToInt32(AddInComingEdgetextBox.Text), Convert.ToInt32(AddOutComingEdgetextBox.Text));
            int zoomValue = trackBar1.Value;
            float zoom = (float)zoomValue / 10;
            EdgesChartComboBox.Items.Add(AddNameTextBoxEdge.Text);
        }

        private void button5_Click(object sender, EventArgs e)//���������� �����
        {
            giSSim.roadMap.Nodes[Convert.ToInt32(UpdateNodeIndexComboBox.Text)].streetNames = UpdateNodeNameTextBox.Text;//���������� ����� 
            giSSim.roadMap.Nodes[Convert.ToInt32(UpdateNodeIndexComboBox.Text)].Coordinates.X = Convert.ToInt32(UpdateXNameTextBox.Text);//���������� X
            giSSim.roadMap.Nodes[Convert.ToInt32(UpdateNodeIndexComboBox.Text)].Coordinates.X = Convert.ToInt32(UpdateYNameTextBox.Text);//���������� X
        }

        private void button6_Click(object sender, EventArgs e)//�������� �����
        {
            giSSim.RemoveNode(giSSim.roadMap.Nodes[Convert.ToInt32(UpdateNodeIndexComboBox.Text)]);
        }

        private void button7_Click(object sender, EventArgs e)//���������� �����
        {
            giSSim.roadMap.Edges[Convert.ToInt32(UpdateEdgeIndexComboBox.Text)].NameGap = UpdateedgeNameTextBox.Text;
            giSSim.roadMap.Edges[Convert.ToInt32(UpdateEdgeIndexComboBox.Text)].Target = giSSim.roadMap.Nodes[Convert.ToInt32(UpdateEdgeNode1TextBox.Text)];
            giSSim.roadMap.Edges[Convert.ToInt32(UpdateEdgeIndexComboBox.Text)].Source = giSSim.roadMap.Nodes[Convert.ToInt32(UpdateEdgeNode2TextBox.Text)];
            giSSim.roadMap.Edges[Convert.ToInt32(UpdateEdgeIndexComboBox.Text)].TraficLightTimeSecond = Convert.ToInt32(UpdateEdgeTrafficLimitTextBox.Text);
            giSSim.roadMap.Edges[Convert.ToInt32(UpdateEdgeIndexComboBox.Text)].Lanes = Convert.ToInt32(UpdateLaneTextBox.Text);
            giSSim.roadMap.Edges[Convert.ToInt32(UpdateEdgeIndexComboBox.Text)].LengthM = Convert.ToInt32(UpdateEdgeLenghtMTextBox.Text);
            giSSim.roadMap.Edges[Convert.ToInt32(UpdateEdgeIndexComboBox.Text)].SpeedLimit = Convert.ToInt32(UpdateEdgeSpeedLimitTextBox.Text);
            giSSim.roadMap.Edges[Convert.ToInt32(UpdateEdgeIndexComboBox.Text)].Incoming = Convert.ToInt32(UpdateEdgeInputTextBox.Text);
            giSSim.roadMap.Edges[Convert.ToInt32(UpdateEdgeIndexComboBox.Text)].Outgoing = Convert.ToInt32(UpdateEdgeOutputTextBox.Text);
        }
        private void PictureBoxClic()
        {
            // ������������� �� ������� ������� ����� �� PictureBox
            pictureBox1.MouseDown += (sender, e) =>
            {
                // ���������, ��� ������ ����� ������ ����
                if (e.Button == MouseButtons.Left)
                {
                    NodeXAddText.Text = settings.X.ToString();
                    NodeYAddText.Text = settings.X.ToString();
                }
            };
        }
        private void button8_Click(object sender, EventArgs e)//�������� �����
        {
            giSSim.RemoveEdge(giSSim.roadMap.Edges[Convert.ToInt32(UpdateEdgeIndexComboBox.Text)]);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)//���������� ������
        {
            ChartStreet.ChartSettings(formsPlot1, roadMap, EdgesChartComboBox, Convert.ToInt32(TimeTextBox.Text));//�������� �������
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            CreateMapForm createMapForm = new();
            createMapForm.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)//��������� ������ � ������
        {
            ChartLoadInExcel.ExcelSave(roadMap, EdgesChartComboBox);
        }

        private void button11_Click(object sender, EventArgs e)//��������� ������
        {
            WeatherSettings weatherSettings = new();
            weatherSettings.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)//������� ������ ������� ������
        {
            // ���������, ������ �� ������
            if (checkBox1.Checked)
            {
                // ���� ������ ������, ��������� ������
                button11.Enabled = true;

            }
            else
            {
                // ���� ������ �� ������, ������������ ������
                button11.Enabled = false;
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ����������ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DBForm DB = new();
            DB.ShowDialog();
        }

        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void �������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void UpdateNodeIndexComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(UpdateNodeIndexComboBox.Text);
            UpdateNodeNameTextBox.Text = giSSim.roadMap.Nodes[ID].streetNames;
            UpdateXNameTextBox.Text = giSSim.roadMap.Nodes[ID].Coordinates.X.ToString();
            UpdateYNameTextBox.Text = giSSim.roadMap.Nodes[ID].Coordinates.Y.ToString();
        }

        private void UpdateXNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbersAndDots(sender, e);
        }

        private void UpdateYNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbersAndDots(sender, e);
        }
        private static void OnlyNumbersAndDots(object sender, KeyPressEventArgs e)//������ ����� � �����
        {
            // ��������, �������� �� ��������� ������ ������ ��� �������
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true; // ���� ������ �� �������� ������, ������� ��� ������, ���������� ���
            }

            // ��������, ����� �� ������� ������ ����� ����� ��� �������
            if ((e.KeyChar == '.' || e.KeyChar == ',') &&
                ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1 || (sender as System.Windows.Forms.TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true; // ���� � TextBox ��� ���� ����� ��� �������, ���������� ���� ��� �����
            }
        }
        private static void OnlyNumbers(object sender, KeyPressEventArgs e)//������ ����� � �����
        {
            // ��������� ���� ������ ���� � ����������� ������
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // ���� ������ �� �������� ������ ��� ����������� ��������, ���������� ���
            }
        }
        private void UpdateEdgeTrafficLimitTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbers(sender, e);
        }

        private void UpdateLaneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbers(sender, e);
        }

        private void UpdateEdgeLenghtMTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbers(sender, e);
        }

        private void UpdateEdgeSpeedLimitTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void UpdateEdgeSpeedLimitTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbers(sender, e);
        }

        private void UpdateEdgeInputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbers(sender, e);
        }

        private void UpdateEdgeOutputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbers(sender, e);
        }

        private void NodeXAddText_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbersAndDots(sender, e);
        }

        private void NodeYAddText_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbersAndDots(sender, e);
        }

        private void AddTrafficTimeTextBoxEdge_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbers(sender, e);
        }

        private void AddLinesEdgeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbers(sender, e);
        }

        private void AddLenghtMTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbers(sender, e);
        }

        private void AddSpeedLimitTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbers(sender, e);
        }

        private void AddInComingEdgetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbers(sender, e);
        }

        private void AddOutComingEdgetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbers(sender, e);
        }

        private void ItearationTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbers(sender, e);
        }

        private void TimeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbers(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Scroll(object sender, ScrollEventArgs e)//�������� ��� ������ ��������
        {
            if (launchIndicator)
            {
                int zoomValue = trackBar1.Value;
                float zoom = (float)zoomValue / 10;
                DrawGraphPicture.DrawGraph(pictureBox1, zoom, Convert.ToInt32(numericUpDown1.Value), roadMap, label3, dataGridView1);
                DrawGraphPicture.DrawPicture(pictureBox1, zoom, roadMap);
            }
        }

        private void UpdateEdgeIndexComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(UpdateEdgeIndexComboBox.Text);
            UpdateedgeNameTextBox.Text = giSSim.roadMap.Edges[ID].NameGap;
            UpdateEdgeNode1TextBox.Text = giSSim.roadMap.Edges[ID].Source.Id.ToString();
            UpdateEdgeNode2TextBox.Text = giSSim.roadMap.Edges[ID].Target.Id.ToString();
            UpdateEdgeTrafficLimitTextBox.Text = giSSim.roadMap.Edges[ID].TraficLightTimeSecond.ToString();
            UpdateLaneTextBox.Text = giSSim.roadMap.Edges[ID].Lanes.ToString();
            UpdateEdgeLenghtMTextBox.Text = giSSim.roadMap.Edges[ID].LengthM.ToString();
            UpdateEdgeSpeedLimitTextBox.Text = giSSim.roadMap.Edges[ID].SpeedLimit.ToString();
            UpdateEdgeInputTextBox.Text = giSSim.roadMap.Edges[ID].Incoming.ToString();
            UpdateEdgeOutputTextBox.Text = giSSim.roadMap.Edges[ID].Outgoing.ToString();
        }

        private void EdgesChartComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }

        public CreateMapForm CreateMapForm
        {
            get => default;
            set
            {
            }
        }

        public DBForm DBForm
        {
            get => default;
            set
            {
            }
        }

        public WeatherSettings WeatherSettings
        {
            get => default;
            set
            {
            }
        }

        public DrawGraphPicture DrawGraphPicture
        {
            get => default;
            set
            {
            }
        }

        internal ChartLoadInExcel ChartLoadInExcel
        {
            get => default;
            set
            {
            }
        }

        internal StartingOperation StartingOperation
        {
            get => default;
            set
            {
            }
        }
    }
}