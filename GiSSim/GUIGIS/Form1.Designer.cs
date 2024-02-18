namespace GUIGIS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            Управление = new TabControl();
            Настройки = new TabPage();
            tabControl2 = new TabControl();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            Добавление = new TabPage();
            tabControl3 = new TabControl();
            tabPage5 = new TabPage();
            tabPage6 = new TabPage();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            groupBox2 = new GroupBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            splitContainer1 = new SplitContainer();
            Koord = new Label();
            label4 = new Label();
            trackBar1 = new TrackBar();
            button3 = new Button();
            label3 = new Label();
            numericUpDown1 = new NumericUpDown();
            groupBox3 = new GroupBox();
            button2 = new Button();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            tabPage2 = new TabPage();
            bindingSource1 = new BindingSource(components);
            panel12 = new Panel();
            groupBox1.SuspendLayout();
            Управление.SuspendLayout();
            Настройки.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage3.SuspendLayout();
            Добавление.SuspendLayout();
            tabControl3.SuspendLayout();
            menuStrip1.SuspendLayout();
            groupBox2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Управление);
            groupBox1.Controls.Add(menuStrip1);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(278, 604);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Управление";
            // 
            // Управление
            // 
            Управление.Controls.Add(Настройки);
            Управление.Controls.Add(Добавление);
            Управление.Dock = DockStyle.Fill;
            Управление.Location = new Point(3, 51);
            Управление.Name = "Управление";
            Управление.SelectedIndex = 0;
            Управление.Size = new Size(272, 550);
            Управление.TabIndex = 0;
            // 
            // Настройки
            // 
            Настройки.Controls.Add(tabControl2);
            Настройки.Location = new Point(4, 29);
            Настройки.Name = "Настройки";
            Настройки.Padding = new Padding(3);
            Настройки.Size = new Size(264, 517);
            Настройки.TabIndex = 0;
            Настройки.Text = "Настройка";
            Настройки.UseVisualStyleBackColor = true;
            Настройки.Click += Настройки_Click;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage3);
            tabControl2.Controls.Add(tabPage4);
            tabControl2.Dock = DockStyle.Fill;
            tabControl2.Location = new Point(3, 3);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(258, 511);
            tabControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(panel12);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(250, 478);
            tabPage3.TabIndex = 0;
            tabPage3.Text = "Узлы";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(250, 478);
            tabPage4.TabIndex = 1;
            tabPage4.Text = "Рёбра";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // Добавление
            // 
            Добавление.Controls.Add(tabControl3);
            Добавление.Location = new Point(4, 29);
            Добавление.Name = "Добавление";
            Добавление.Padding = new Padding(3);
            Добавление.Size = new Size(264, 517);
            Добавление.TabIndex = 1;
            Добавление.Text = "Добавление";
            Добавление.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            tabControl3.Controls.Add(tabPage5);
            tabControl3.Controls.Add(tabPage6);
            tabControl3.Dock = DockStyle.Fill;
            tabControl3.Location = new Point(3, 3);
            tabControl3.Name = "tabControl3";
            tabControl3.SelectedIndex = 0;
            tabControl3.Size = new Size(258, 511);
            tabControl3.TabIndex = 1;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 29);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(250, 478);
            tabPage5.TabIndex = 0;
            tabPage5.Text = "Узлы";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            tabPage6.Location = new Point(4, 29);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new Padding(3);
            tabPage6.Size = new Size(250, 478);
            tabPage6.TabIndex = 1;
            tabPage6.Text = "Рёбра";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem });
            menuStrip1.Location = new Point(3, 23);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(272, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { открытьToolStripMenuItem, сохранитьToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(59, 24);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(166, 26);
            открытьToolStripMenuItem.Text = "Открыть";
            открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(166, 26);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            сохранитьToolStripMenuItem.Click += сохранитьToolStripMenuItem_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tabControl1);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(278, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(821, 604);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Граф";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(3, 23);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(815, 578);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(splitContainer1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(807, 545);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Карта";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(Koord);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(trackBar1);
            splitContainer1.Panel2.Controls.Add(button3);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(numericUpDown1);
            splitContainer1.Panel2.Controls.Add(groupBox3);
            splitContainer1.Size = new Size(801, 539);
            splitContainer1.SplitterDistance = 370;
            splitContainer1.TabIndex = 1;
            // 
            // Koord
            // 
            Koord.AutoSize = true;
            Koord.Location = new Point(3, 145);
            Koord.Name = "Koord";
            Koord.Size = new Size(21, 20);
            Koord.TabIndex = 6;
            Koord.Text = "--";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 63);
            label4.Name = "label4";
            label4.Size = new Size(143, 20);
            label4.TabIndex = 5;
            label4.Text = "Изменить масштаб";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(3, 86);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(444, 56);
            trackBar1.TabIndex = 4;
            // 
            // button3
            // 
            button3.Location = new Point(81, 31);
            button3.Name = "button3";
            button3.Size = new Size(210, 29);
            button3.TabIndex = 3;
            button3.Text = "Отобразить шаг";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 3);
            label3.Name = "label3";
            label3.Size = new Size(275, 20);
            label3.TabIndex = 2;
            label3.Text = "Средний коофициент загруженности: ";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(297, 31);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 1;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button2);
            groupBox3.Controls.Add(textBox2);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(textBox1);
            groupBox3.Controls.Add(label1);
            groupBox3.Location = new Point(453, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(345, 141);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            // 
            // button2
            // 
            button2.Location = new Point(242, 95);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 4;
            button2.Text = "Запуск";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(227, 60);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(109, 27);
            textBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 60);
            label2.Name = "label2";
            label2.Size = new Size(214, 20);
            label2.TabIndex = 2;
            label2.Text = "Временные интервалы (мин)";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(227, 26);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(109, 27);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 23);
            label1.Name = "label1";
            label1.Size = new Size(161, 20);
            label1.TabIndex = 0;
            label1.Text = "Количество итераций";
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(807, 545);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "График";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel12
            // 
            panel12.Location = new Point(8, 143);
            panel12.Name = "panel12";
            panel12.Size = new Size(250, 125);
            panel12.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1099, 604);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            Управление.ResumeLayout(false);
            Настройки.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            Добавление.ResumeLayout(false);
            tabControl3.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TabControl Управление;
        private TabPage Настройки;
        private TabPage Добавление;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private BindingSource bindingSource1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private GroupBox groupBox3;
        private Button button2;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private SplitContainer splitContainer1;
        private NumericUpDown numericUpDown1;
        private Button button3;
        private Label label3;
        private TabControl tabControl2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabControl tabControl3;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private Label label4;
        private TrackBar trackBar1;
        private Label Koord;
        private Panel panel12;
    }
}