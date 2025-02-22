using HotelManagementSystem.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class DashboardHomeForm : Form
    {
        public DashboardHomeForm()
        {
            InitializeComponent();
        }

        private void DashboardHomeForm_Load(object sender, EventArgs e)
        {
            LoadDashboardData();

        }
        private void LoadDashboardData()
        {
            using (var db = new ApplicationDbContext()) // Connect to DB
            {
                lblTotalEmployees.Text = "Total Employees: " + db.Employees.Count().ToString();

                lblAvailableRooms.Text = "Available Rooms: " + db.Rooms.Count(r => r.Availability).ToString();

                lblOccupiedRooms.Text = "Occupied Rooms: " + db.Rooms.Count(r => !r.Availability).ToString();

                lblUpcomingReservations.Text = "Upcoming Reservations: " + db.Reservations.Count(r => r.CheckInDate > DateTime.Now).ToString();

                dataGridViewRecentReservations.DataSource = db.Reservations
    .Select(r => new { r.CustomerName, r.CheckInDate, r.CheckOutDate, r.Status })
    .ToList();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewRecentReservations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblUpcomingReservations_Click(object sender, EventArgs e)
        {

        }

        private void lblAvailableRooms_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
