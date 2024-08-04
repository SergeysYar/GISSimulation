using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIGIS
{
    public partial class DBForm : Form
    {
        public DBForm()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string host = textBox1.Text;
            string username = textBox2.Text;
            string password = textBox3.Text;
            string database = textBox4.Text;

            string connectionString = $"Server={host};Database={database};Uid={username};Pwd={password};";

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                label5.Text = "Подключение успешно установлено!";
                button1.Enabled = true;
                // Выполнение SQL-запроса
                string query = "SELECT * FROM YourTable";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                // Обработка полученных данных
                while (reader.Read())
                {
                    // Пример: вывод полученных данных в MessageBox
                    MessageBox.Show($"Column1: {reader["Column1"]}, Column2: {reader["Column2"]}");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                label5.Text = $"Ошибка подключения: {ex.Message}";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
