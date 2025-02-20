namespace HotelManagementSystem
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(82, 102, 93);
            label1.Location = new Point(131, 48);
            label1.Name = "label1";
            label1.Size = new Size(527, 37);
            label1.TabIndex = 0;
            label1.Text = "Welcome to Hotel Management System";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(84, 101, 93);
            label2.Location = new Point(24, 136);
            label2.Name = "label2";
            label2.Size = new Size(146, 37);
            label2.TabIndex = 1;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(84, 101, 93);
            label3.Location = new Point(31, 239);
            label3.Name = "label3";
            label3.Size = new Size(139, 37);
            label3.TabIndex = 2;
            label3.Text = "Password";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(242, 242, 242);
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.ForeColor = Color.Black;
            textBox1.Location = new Point(200, 141);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(424, 34);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(242, 242, 242);
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Segoe UI", 12F);
            textBox2.Location = new Point(200, 239);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(424, 34);
            textBox2.TabIndex = 4;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(82, 102, 93);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(242, 242, 242);
            button1.Location = new Point(282, 334);
            button1.Name = "button1";
            button1.Size = new Size(191, 55);
            button1.TabIndex = 7;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            button1.MouseLeave += button1_MouseLeave;
            button1.MouseHover += button1_MouseHover;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hotel Management System";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
    }
}
