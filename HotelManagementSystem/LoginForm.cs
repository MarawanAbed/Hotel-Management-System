using BL.Services.Abstraction;
using BL.Services.Implementation;
using Dal.Entities;
using Dal.Repo.Implementation;
using HotelManagementSystem.database;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class LoginForm : Form
    {
        private readonly IUserServices _userService;

        public LoginForm()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            var context = new ApplicationDbContext();
            var userRepository = new UserRepo(context);
            _userService = new UserServices(userRepository);

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(0x34, 0x98, 0xDB);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(0x2C, 0x3E, 0x50);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            User user = _userService.AuthenticateUser(username, password);
            if (user != null)
            {
                MessageBox.Show("Login successful!");
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }

        }


        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
