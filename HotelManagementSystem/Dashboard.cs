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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDashboard_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnDashboard_MouseLeave(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new DashboardHomeForm()); // Load Dashboard content

        }
        private void LoadFormInPanel(Form form)
        {
            panelMainContent.Controls.Clear(); // Clear previous form
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelMainContent.Controls.Add(form);
            form.Show();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new EmployeeManagementHome()); // Load Employee Management content
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new RoomManagement()); // Load Room Management content
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new Reservations()); // Load Reservation Management content
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
