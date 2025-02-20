namespace HotelManagementSystem
{
    partial class DashboardHomeForm
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
            lblTotalEmployees = new Label();
            lblAvailableRooms = new Label();
            lblOccupiedRooms = new Label();
            lblUpcomingReservations = new Label();
            label1 = new Label();
            dataGridViewRecentReservations = new DataGridView();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRecentReservations).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTotalEmployees
            // 
            lblTotalEmployees.AutoSize = true;
            lblTotalEmployees.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalEmployees.ForeColor = Color.FromArgb(44, 62, 80);
            lblTotalEmployees.Location = new Point(33, 34);
            lblTotalEmployees.Name = "lblTotalEmployees";
            lblTotalEmployees.Size = new Size(227, 37);
            lblTotalEmployees.TabIndex = 2;
            lblTotalEmployees.Text = "Total Employees";
            // 
            // lblAvailableRooms
            // 
            lblAvailableRooms.AutoSize = true;
            lblAvailableRooms.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblAvailableRooms.ForeColor = Color.FromArgb(44, 62, 80);
            lblAvailableRooms.Location = new Point(33, 102);
            lblAvailableRooms.Name = "lblAvailableRooms";
            lblAvailableRooms.Size = new Size(231, 37);
            lblAvailableRooms.TabIndex = 3;
            lblAvailableRooms.Text = "Available Rooms";
            // 
            // lblOccupiedRooms
            // 
            lblOccupiedRooms.AutoSize = true;
            lblOccupiedRooms.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblOccupiedRooms.ForeColor = Color.FromArgb(44, 62, 80);
            lblOccupiedRooms.Location = new Point(348, 102);
            lblOccupiedRooms.Name = "lblOccupiedRooms";
            lblOccupiedRooms.Size = new Size(231, 37);
            lblOccupiedRooms.TabIndex = 4;
            lblOccupiedRooms.Text = "Occupied Rooms";
            // 
            // lblUpcomingReservations
            // 
            lblUpcomingReservations.AutoSize = true;
            lblUpcomingReservations.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblUpcomingReservations.ForeColor = Color.FromArgb(44, 62, 80);
            lblUpcomingReservations.Location = new Point(348, 34);
            lblUpcomingReservations.Name = "lblUpcomingReservations";
            lblUpcomingReservations.Size = new Size(322, 37);
            lblUpcomingReservations.TabIndex = 5;
            lblUpcomingReservations.Text = "Upcoming Reservations";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(44, 62, 80);
            label1.Location = new Point(246, 0);
            label1.Name = "label1";
            label1.Size = new Size(276, 37);
            label1.TabIndex = 6;
            label1.Text = "Recent Reservations\t";
            // 
            // dataGridViewRecentReservations
            // 
            dataGridViewRecentReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewRecentReservations.BackgroundColor = Color.White;
            dataGridViewRecentReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridViewRecentReservations.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewRecentReservations.Dock = DockStyle.Bottom;
            dataGridViewRecentReservations.GridColor = Color.FromArgb(44, 62, 80);
            dataGridViewRecentReservations.Location = new Point(0, 307);
            dataGridViewRecentReservations.Name = "dataGridViewRecentReservations";
            dataGridViewRecentReservations.RowHeadersWidth = 51;
            dataGridViewRecentReservations.Size = new Size(800, 143);
            dataGridViewRecentReservations.TabIndex = 7;
            dataGridViewRecentReservations.CellContentClick += dataGridViewRecentReservations_CellContentClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 237);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 70);
            panel1.TabIndex = 8;
            // 
            // DashboardHomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(dataGridViewRecentReservations);
            Controls.Add(lblUpcomingReservations);
            Controls.Add(lblOccupiedRooms);
            Controls.Add(lblAvailableRooms);
            Controls.Add(lblTotalEmployees);
            Name = "DashboardHomeForm";
            Text = "DashboardHomeForm";
            Load += DashboardHomeForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewRecentReservations).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTotalEmployees;
        private Label lblAvailableRooms;
        private Label lblOccupiedRooms;
        private Label lblUpcomingReservations;
        private Label label1;
        private DataGridView dataGridViewRecentReservations;
        private Panel panel1;
    }
}