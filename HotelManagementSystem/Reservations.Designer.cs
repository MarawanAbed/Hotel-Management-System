namespace HotelManagementSystem
{
    partial class Reservations
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            comboBox2 = new ComboBox();
            label5 = new Label();
            dateTimePicker2 = new DateTimePicker();
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            comboBox1 = new ComboBox();
            button6 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            label3 = new Label();
            label2 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(dateTimePicker2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(906, 299);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Reservations Management";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(144, 157);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(158, 28);
            comboBox2.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 160);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 16;
            label5.Text = "Status";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(545, 96);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(262, 27);
            dateTimePicker2.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(427, 101);
            label4.Name = "label4";
            label4.Size = new Size(112, 20);
            label4.TabIndex = 14;
            label4.Text = "Check-out Date";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(545, 43);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(262, 27);
            dateTimePicker1.TabIndex = 13;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(144, 98);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(158, 28);
            comboBox1.TabIndex = 12;
            // 
            // button6
            // 
            button6.BackColor = SystemColors.MenuHighlight;
            button6.FlatStyle = FlatStyle.Flat;
            button6.ForeColor = SystemColors.Control;
            button6.Location = new Point(439, 233);
            button6.Name = "button6";
            button6.Size = new Size(180, 50);
            button6.TabIndex = 11;
            button6.Text = "Export";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(39, 174, 96);
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = Color.White;
            button4.Location = new Point(6, 233);
            button4.Name = "button4";
            button4.Size = new Size(180, 50);
            button4.TabIndex = 9;
            button4.Text = "Add Reservations";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(231, 76, 60);
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = SystemColors.ControlLightLight;
            button3.Location = new Point(535, 160);
            button3.Name = "button3";
            button3.Size = new Size(180, 50);
            button3.TabIndex = 8;
            button3.Text = "Delete Reservation";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(52, 152, 219);
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = SystemColors.Control;
            button2.Location = new Point(647, 233);
            button2.Name = "button2";
            button2.Size = new Size(180, 50);
            button2.TabIndex = 7;
            button2.Text = "Edit Reservation";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 105);
            label3.Name = "label3";
            label3.Size = new Size(114, 20);
            label3.TabIndex = 5;
            label3.Text = "Room Selection";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(427, 43);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 3;
            label2.Text = "Check-in Date";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.HotTrack;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(230, 233);
            button1.Name = "button1";
            button1.Size = new Size(180, 50);
            button1.TabIndex = 2;
            button1.Text = "Import";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(137, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(268, 27);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 43);
            label1.Name = "label1";
            label1.Size = new Size(116, 20);
            label1.TabIndex = 0;
            label1.Text = "Customer Name";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.GridColor = Color.FromArgb(44, 62, 80);
            dataGridView1.Location = new Point(0, 299);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(906, 151);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.RowHeaderMouseDoubleClick += dataGridView1_RowHeaderMouseDoubleClick;
            // 
            // Reservations
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(906, 450);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox1);
            Name = "Reservations";
            Text = "Reservations";
            Load += Reservations_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button button6;
        private Button button4;
        private Button button3;
        private Button button2;
        private Label label3;
        private Label label2;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label5;
        private DateTimePicker dateTimePicker2;
        private Label label4;
        private DateTimePicker dateTimePicker1;
    }
}