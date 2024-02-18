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
            groupBox1 = new GroupBox();
            Управление = new TabControl();
            Настройки = new TabPage();
            Добавление = new TabPage();
            groupBox2 = new GroupBox();
            pictureBox1 = new PictureBox();
            comboBox1 = new ComboBox();
            groupBox1.SuspendLayout();
            Управление.SuspendLayout();
            Настройки.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Управление);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(278, 450);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Управление";
            // 
            // Управление
            // 
            Управление.Controls.Add(Настройки);
            Управление.Controls.Add(Добавление);
            Управление.Location = new Point(12, 26);
            Управление.Name = "Управление";
            Управление.SelectedIndex = 0;
            Управление.Size = new Size(250, 418);
            Управление.TabIndex = 0;
            // 
            // Настройки
            // 
            Настройки.Controls.Add(comboBox1);
            Настройки.Location = new Point(4, 29);
            Настройки.Name = "Настройки";
            Настройки.Padding = new Padding(3);
            Настройки.Size = new Size(242, 385);
            Настройки.TabIndex = 0;
            Настройки.Text = "Настройка";
            Настройки.UseVisualStyleBackColor = true;
            // 
            // Добавление
            // 
            Добавление.Location = new Point(4, 29);
            Добавление.Name = "Добавление";
            Добавление.Padding = new Padding(3);
            Добавление.Size = new Size(242, 385);
            Добавление.TabIndex = 1;
            Добавление.Text = "Добавление";
            Добавление.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(pictureBox1);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(278, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(515, 450);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Граф";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(3, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(509, 424);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(52, 6);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(184, 28);
            comboBox1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(793, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            Управление.ResumeLayout(false);
            Настройки.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TabControl Управление;
        private TabPage Настройки;
        private TabPage Добавление;
        private PictureBox pictureBox1;
        private ComboBox comboBox1;
    }
}