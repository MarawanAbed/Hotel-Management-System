using BL.Services.Abstraction;
using BL.Services.Implementation;
using Dal.Repo.Implementation;
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
        private readonly IDashBoardServices _dashBoard;
        public DashboardHomeForm()
        {
            InitializeComponent();
            var context=new ApplicationDbContext();
            var dashBoardRepo= new DashBoardRepo(context);
            _dashBoard = new DashBoardServices(dashBoardRepo);
        }

        private void DashboardHomeForm_Load(object sender, EventArgs e)
        {
            LoadDashboardData();

        }
        private void LoadDashboardData()
        {
            
            
                lblTotalEmployees.Text = "Total Employees: " + _dashBoard.GetTotalEmployees().ToString();

            lblAvailableRooms.Text = "Available Rooms: " + _dashBoard.GetAvailableRooms().ToString();

            lblOccupiedRooms.Text = "Occupied Rooms: " + _dashBoard.GetOccupiedRooms().ToString();

            lblUpcomingReservations.Text = "Upcoming Reservations: " + _dashBoard.GetUpcomingReservations().ToString();

            dataGridViewRecentReservations.DataSource = _dashBoard.GetRecentReservations();
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
