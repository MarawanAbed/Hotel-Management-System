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
                // Update label with total employees count
                lblTotalEmployees.Text = "Total Employees: " + db.Employees.Count().ToString();

                // Update label with available rooms count
                lblAvailableRooms.Text = "Available Rooms: " + db.Rooms.Count(r => r.Availability).ToString();

                // Update label with occupied rooms count
                lblOccupiedRooms.Text = "Occupied Rooms: " + db.Rooms.Count(r => !r.Availability).ToString();

                // Update label with upcoming reservations count
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
    }
}
