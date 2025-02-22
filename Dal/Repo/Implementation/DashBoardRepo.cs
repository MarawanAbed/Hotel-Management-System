using Dal.Entities;
using Dal.Repo.Abstraction;
using HotelManagementSystem.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repo.Implementation
{
    public class DashBoardRepo : IDashBoardRepo
    {
        private readonly ApplicationDbContext _context;

        public DashBoardRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public int GetAvailableRooms()
        {
            return _context.Rooms.Count(r => r.Availability);

        }

        public int GetOccupiedRooms()
        {
            return _context.Rooms.Count(r => !r.Availability);
        }

        public List<object> GetRecentReservations()
        {
            return _context.Reservations
                .Select(r => new
                {
                    CustomerName = r.CustomerName,
                    CheckInDate = r.CheckInDate,
                    CheckOutDate = r.CheckOutDate,
                    Status = r.Status
                })
                .ToList<object>();
        }

        public int GetTotalEmployees()
        {
            return _context.Employees.Count();
        }

        public int GetUpcomingReservations()
        {
            return _context.Reservations.Count(r => r.CheckInDate > DateTime.Now);
        }
    }
}
