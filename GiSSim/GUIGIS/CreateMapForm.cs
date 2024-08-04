using GiSSim;
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
    public partial class CreateMapForm : Form
    {
        public CreateMapForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//создать
        {
            GiSSim.GiSSim giSSim = new(textBox1.Text);
            Form1.giSSim = giSSim;
        }
    }
}
