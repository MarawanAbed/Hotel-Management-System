using HotelManagementSystem.database;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
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

            // Hash the password
            string hashedPassword = HashPassword(password);

            // Validate credentials using EF Core
            using (var context = new ApplicationDbContext())
            {
                var user = context.Users
                    .FirstOrDefault(u => u.Username == username && u.PasswordHash == hashedPassword);

                if (user != null)
                {
                    MessageBox.Show("Login successful!");
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Hide(); // Hide the login form
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
        }
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
