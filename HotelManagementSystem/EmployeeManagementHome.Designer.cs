namespace HotelManagementSystem
{
    partial class EmployeeManagementHome
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            groupBox1 = new GroupBox();
            button6 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(994, 450);
            panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle2.BackColor = Color.WhiteSmoke;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.GridColor = Color.FromArgb(44, 62, 80);
            dataGridView1.Location = new Point(0, 299);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(994, 151);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            dataGridView1.RowHeaderMouseDoubleClick += dataGridView1_RowHeaderMouseDoubleClick;
            dataGridView1.MouseDoubleClick += dataGridView1_MouseDoubleClick;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(82, 102, 93);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(994, 299);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Employee Management";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(82, 102, 93);
            button6.FlatStyle = FlatStyle.Flat;
            button6.ForeColor = Color.FromArgb(242, 242, 242);
            button6.Location = new Point(751, 78);
            button6.Name = "button6";
            button6.Size = new Size(180, 50);
            button6.TabIndex = 11;
            button6.Text = "Export";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(82, 102, 93);
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = Color.FromArgb(242, 242, 242);
            button4.Location = new Point(751, 239);
            button4.Name = "button4";
            button4.Size = new Size(180, 51);
            button4.TabIndex = 9;
            button4.Text = "Add Employee";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(82, 102, 93);
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.FromArgb(242, 242, 242);
            button3.Location = new Point(751, 132);
            button3.Name = "button3";
            button3.Size = new Size(180, 50);
            button3.TabIndex = 8;
            button3.Text = "Delete Employee";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(82, 102, 93);
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.FromArgb(242, 242, 242);
            button2.Location = new Point(751, 22);
            button2.Name = "button2";
            button2.Size = new Size(180, 50);
            button2.TabIndex = 7;
            button2.Text = "Edit Employee";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(242, 242, 242);
            textBox3.Location = new Point(233, 143);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(268, 38);
            textBox3.TabIndex = 6;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(84, 101, 93);
            label3.Location = new Point(159, 143);
            label3.Name = "label3";
            label3.Size = new Size(60, 23);
            label3.TabIndex = 5;
            label3.Text = "Salary";
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(242, 242, 242);
            textBox2.Location = new Point(233, 222);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(268, 38);
            textBox2.TabIndex = 4;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(84, 101, 93);
            label2.Location = new Point(159, 222);
            label2.Name = "label2";
            label2.Size = new Size(73, 23);
            label2.TabIndex = 3;
            label2.Text = "Position";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(82, 102, 93);
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.FromArgb(242, 242, 242);
            button1.Location = new Point(751, 185);
            button1.Name = "button1";
            button1.Size = new Size(180, 50);
            button1.TabIndex = 2;
            button1.Text = "Import";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(242, 242, 242);
            textBox1.Location = new Point(233, 64);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(268, 38);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(84, 101, 93);
            label1.Location = new Point(162, 70);
            label1.Name = "label1";
            label1.Size = new Size(57, 23);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // EmployeeManagementHome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(994, 450);
            Controls.Add(panel1);
            Name = "EmployeeManagementHome";
            Text = "EmployeeManagementHome";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private GroupBox groupBox1;
        private TextBox textBox2;
        private Label label2;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private Button button3;
        private Button button2;
        private TextBox textBox3;
        private Label label3;
        private DataGridView dataGridView1;
        private Button button4;
        private Button button6;
    }
}