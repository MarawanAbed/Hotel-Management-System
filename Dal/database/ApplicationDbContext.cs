using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;


namespace HotelManagementSystem.database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=hoteltest4;Trusted_Connection=True;MultipleActiveResultSets=true;trustServerCertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Room)
                .WithMany(room => room.Reservations)
                .HasForeignKey(r => r.RoomID);

            modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, Username = "admin", PasswordHash = HashPassword("admin123") }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeID = 1, Name = "John Doe", Position = "Manager", Salary = 5000 },
                new Employee { EmployeeID = 2, Name = "Jane Smith", Position = "Receptionist", Salary = 3000 },
                new Employee { EmployeeID = 3, Name = "Mike Johnson", Position = "Housekeeping", Salary = 2500 }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room { RoomID = 1, RoomNumber = "101", Type = "Single", Price = 50, Availability = true },
                new Room { RoomID = 2, RoomNumber = "102", Type = "Double", Price = 80, Availability = false },
                new Room { RoomID = 3, RoomNumber = "103", Type = "Suite", Price = 150, Availability = true },
                new Room { RoomID = 4, RoomNumber = "104", Type = "Single", Price = 55, Availability = true }
            );

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation { ReservationID = 1, CustomerName = "Alice Johnson", CheckInDate = new DateTime(2025, 2, 20), CheckOutDate = new DateTime(2025, 2, 23), Status = ReservationStatus.Upcoming, RoomID = 2 },
                new Reservation { ReservationID = 2, CustomerName = "Bob Williams", CheckInDate = new DateTime(2025, 2, 15), CheckOutDate = new DateTime(2025, 2, 20), Status = ReservationStatus.Ongoing, RoomID = 1 },
                new Reservation { ReservationID = 3, CustomerName = "Charlie Brown", CheckInDate = new DateTime(2025, 1, 10), CheckOutDate = new DateTime(2025, 1, 15), Status = ReservationStatus.CheckedOut, RoomID = 3 },
                new Reservation { ReservationID = 4, CustomerName = "David White", CheckInDate = new DateTime(2025, 3, 1), CheckOutDate = new DateTime(2025, 3, 5), Status = ReservationStatus.Canceled, RoomID = 4 },
                new Reservation { ReservationID = 5, CustomerName = "Eva Green", CheckInDate = new DateTime(2025, 2, 18), CheckOutDate = new DateTime(2025, 2, 22), Status = ReservationStatus.NoShow, RoomID = 1 }
            );
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
