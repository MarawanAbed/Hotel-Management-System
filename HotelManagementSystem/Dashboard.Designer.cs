namespace HotelManagementSystem
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            panelSidebar = new Panel();
            btnLogout = new Button();
            btnReservations = new Button();
            btnRooms = new Button();
            btnEmployee = new Button();
            btnDashboard = new Button();
            panelMainContent = new Panel();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(44, 62, 80);
            panelSidebar.Controls.Add(btnLogout);
            panelSidebar.Controls.Add(btnReservations);
            panelSidebar.Controls.Add(btnRooms);
            panelSidebar.Controls.Add(btnEmployee);
            panelSidebar.Controls.Add(btnDashboard);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(200, 585);
            panelSidebar.TabIndex = 0;
            panelSidebar.Paint += panel1_Paint;
            // 
            // btnLogout
            // 
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(10, 435);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(180, 50);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnReservations
            // 
            btnReservations.FlatStyle = FlatStyle.Flat;
            btnReservations.ForeColor = Color.White;
            btnReservations.Location = new Point(12, 333);
            btnReservations.Name = "btnReservations";
            btnReservations.Size = new Size(180, 50);
            btnReservations.TabIndex = 7;
            btnReservations.Text = "Reservations";
            btnReservations.UseVisualStyleBackColor = true;
            btnReservations.Click += btnReservations_Click;
            // 
            // btnRooms
            // 
            btnRooms.FlatStyle = FlatStyle.Flat;
            btnRooms.ForeColor = Color.White;
            btnRooms.Location = new Point(12, 239);
            btnRooms.Name = "btnRooms";
            btnRooms.Size = new Size(180, 50);
            btnRooms.TabIndex = 6;
            btnRooms.Text = "Room Management";
            btnRooms.UseVisualStyleBackColor = true;
            btnRooms.Click += btnRooms_Click;
            // 
            // btnEmployee
            // 
            btnEmployee.FlatStyle = FlatStyle.Flat;
            btnEmployee.ForeColor = Color.White;
            btnEmployee.Location = new Point(12, 135);
            btnEmployee.Name = "btnEmployee";
            btnEmployee.Size = new Size(180, 50);
            btnEmployee.TabIndex = 5;
            btnEmployee.Text = "Employee Management\t";
            btnEmployee.UseVisualStyleBackColor = true;
            btnEmployee.Click += btnEmployee_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(12, 41);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(180, 50);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            btnDashboard.MouseLeave += btnDashboard_MouseLeave;
            btnDashboard.MouseHover += btnDashboard_MouseHover;
            // 
            // panelMainContent
            // 
            panelMainContent.BackColor = Color.FromArgb(236, 240, 241);
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(200, 0);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Size = new Size(762, 585);
            panelMainContent.TabIndex = 1;
            panelMainContent.Paint += panel2_Paint;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(962, 585);
            Controls.Add(panelMainContent);
            Controls.Add(panelSidebar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Dashboard";
            Text = "Dashboard";
            panelSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSidebar;
        private Panel panelMainContent;
        private Button btnDashboard;
        private Button btnLogout;
        private Button btnReservations;
        private Button btnRooms;
        private Button btnEmployee;
    }
}