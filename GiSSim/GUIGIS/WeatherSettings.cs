using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherAnalysis;

namespace GUIGIS
{
    public partial class WeatherSettings : Form
    {
        public WeatherSettings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckFields();
        }
        private void CheckFields()
        {
            // Проверка для первого варианта
            if (!string.IsNullOrEmpty(textBox1.Text) 
                && !string.IsNullOrEmpty(textBox2.Text) 
                && !string.IsNullOrEmpty(textBox3.Text))
            {
                Form1.indexWeather = ActivateWeatherAnalysis.GetManualWeather(textBox1.Text, textBox2.Text, textBox3.Text);
                //Form1.DeblokButton2();
            }

            // Проверка для второго варианта
            else if (comboBox1.SelectedItem != null 
                && dateTimePicker1.Value != null)
            {
                Form1.indexWeather = ActivateWeatherAnalysis.GetAPIWeather(comboBox1.Text, dateTimePicker1.Text);
                //Form1.DeblokButton2();
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните поля");
            }
        }
    }
}
