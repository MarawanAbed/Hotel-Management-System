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
    public class RoomRepo : IRoomRepo
    {
        private readonly ApplicationDbContext _context;

        public RoomRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public void DeleteRoom(int roomId)
        {
            var room = _context.Rooms.Find(roomId);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
        }

        public List<Room> GetAll()
        {
           return _context.Rooms.ToList();
        }

        public List<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }

        public Room GetRoomById(int roomId)
        {
            return _context.Rooms.FirstOrDefault(e => e.RoomID == roomId);
        }

        public void UpdateRoom(Room room)
        {
            var rooms = _context.Rooms.FirstOrDefault(e => e.RoomID == room.RoomID);
            if (rooms != null)
            {
                rooms.RoomNumber = room.RoomNumber;
                rooms.Type = room.Type;
                rooms.Price = room.Price;
                rooms.Availability = room.Availability;
                _context.SaveChanges();
            }
            _context.SaveChanges();
        }
    }
}
