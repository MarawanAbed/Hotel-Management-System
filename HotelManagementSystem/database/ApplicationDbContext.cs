using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
            optionsBuilder.UseSqlServer("Server=.;Database=Hotel;Trusted_Connection=True;MultipleActiveResultSets=true;trustServerCertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the one-to-many relationship between Room and Reservation
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Room)
                .WithMany(room => room.Reservations)
                .HasForeignKey(r => r.RoomID);

            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, Username = "admin", PasswordHash = HashPassword("admin123") }
            );

            // Seed Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeID = 1, Name = "John Doe", Position = "Manager", Salary = 5000 },
                new Employee { EmployeeID = 2, Name = "Jane Smith", Position = "Receptionist", Salary = 3000 },
                new Employee { EmployeeID = 3, Name = "Mike Johnson", Position = "Housekeeping", Salary = 2500 }
            );

            // Seed Rooms
            modelBuilder.Entity<Room>().HasData(
                new Room { RoomID = 1, RoomNumber = "101", Type = "Single", Price = 50, Availability = true },
                new Room { RoomID = 2, RoomNumber = "102", Type = "Double", Price = 80, Availability = false },
                new Room { RoomID = 3, RoomNumber = "103", Type = "Suite", Price = 150, Availability = true },
                new Room { RoomID = 4, RoomNumber = "104", Type = "Single", Price = 55, Availability = true }
            );

            // Seed Reservations
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


    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
    }

    public class Room
    {
        public int RoomID { get; set; }
        public string RoomNumber { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public bool Availability { get; set; } = true;

        // Navigation property for Reservations
        public ICollection<Reservation> Reservations { get; set; }
    }
    public enum ReservationStatus
    {
        Upcoming,   // Booking is confirmed but check-in hasn't happened yet
        Ongoing,    // Guest has checked in
        CheckedOut, // Guest has left, room should be available
        Canceled,   // Reservation was canceled
        NoShow      // Guest didn't show up
    }

    public class Reservation
    {
        public int ReservationID { get; set; }
        public string CustomerName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public ReservationStatus Status { get; set; }  // Updated type from string to enum

        public int RoomID { get; set; }
        public Room Room { get; set; }
    }
}
