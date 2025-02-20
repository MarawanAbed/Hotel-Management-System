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
            panelSidebar.BackColor = Color.FromArgb(84, 101, 93);
            panelSidebar.BorderStyle = BorderStyle.Fixed3D;
            panelSidebar.Controls.Add(btnLogout);
            panelSidebar.Controls.Add(btnReservations);
            panelSidebar.Controls.Add(btnRooms);
            panelSidebar.Controls.Add(btnEmployee);
            panelSidebar.Controls.Add(btnDashboard);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(215, 585);
            panelSidebar.TabIndex = 0;
            panelSidebar.Paint += panel1_Paint;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(242, 242, 242);
            btnLogout.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.FromArgb(84, 101, 93);
            btnLogout.Location = new Point(12, 428);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(180, 50);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnReservations
            // 
            btnReservations.BackColor = Color.FromArgb(242, 242, 242);
            btnReservations.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReservations.ForeColor = Color.FromArgb(84, 101, 93);
            btnReservations.Location = new Point(12, 336);
            btnReservations.Name = "btnReservations";
            btnReservations.Size = new Size(180, 50);
            btnReservations.TabIndex = 7;
            btnReservations.Text = "Reservations";
            btnReservations.UseVisualStyleBackColor = false;
            btnReservations.Click += btnReservations_Click;
            // 
            // btnRooms
            // 
            btnRooms.BackColor = Color.FromArgb(242, 242, 242);
            btnRooms.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRooms.ForeColor = Color.FromArgb(84, 101, 93);
            btnRooms.Location = new Point(12, 239);
            btnRooms.Name = "btnRooms";
            btnRooms.Size = new Size(180, 62);
            btnRooms.TabIndex = 6;
            btnRooms.Text = "Room Management";
            btnRooms.UseVisualStyleBackColor = false;
            btnRooms.Click += btnRooms_Click;
            // 
            // btnEmployee
            // 
            btnEmployee.BackColor = Color.FromArgb(242, 242, 242);
            btnEmployee.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEmployee.ForeColor = Color.FromArgb(84, 101, 93);
            btnEmployee.Location = new Point(12, 135);
            btnEmployee.Name = "btnEmployee";
            btnEmployee.Size = new Size(180, 65);
            btnEmployee.TabIndex = 5;
            btnEmployee.Text = "Employee Management\t";
            btnEmployee.UseVisualStyleBackColor = false;
            btnEmployee.Click += btnEmployee_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.FromArgb(242, 242, 242);
            btnDashboard.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.FromArgb(84, 101, 93);
            btnDashboard.Location = new Point(12, 41);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(180, 58);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            btnDashboard.MouseLeave += btnDashboard_MouseLeave;
            btnDashboard.MouseHover += btnDashboard_MouseHover;
            // 
            // panelMainContent
            // 
            panelMainContent.BackColor = Color.WhiteSmoke;
            panelMainContent.BackgroundImage = (Image)resources.GetObject("panelMainContent.BackgroundImage");
            panelMainContent.BackgroundImageLayout = ImageLayout.Stretch;
            panelMainContent.BorderStyle = BorderStyle.Fixed3D;
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(215, 0);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Size = new Size(747, 585);
            panelMainContent.TabIndex = 1;
            panelMainContent.Paint += panel2_Paint;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
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