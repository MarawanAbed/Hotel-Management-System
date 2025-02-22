using BL.Services.Abstraction;
using Dal.Entities;
using Dal.Repo.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Implementation
{
    public class RoomServices : IRoomServices
    {
        private readonly IRoomRepo _room;

        public RoomServices(IRoomRepo roomRepo)
        {
            _room = roomRepo;
        }

        public void AddRoom(Room room)
        {
            _room.AddRoom(room);
        }

        public void DeleteRoom(int roomId)
        {
            _room.DeleteRoom(roomId);
        }

        public List<object> GetAllRooms()
        {
            
                var rooms = _room.GetAllRooms();
                return rooms.Select(r => new
                {
                    r.RoomID,
                    r.RoomNumber,
                    r.Type,
                    r.Price,
                    Availability = r.Availability ? "Available" : "Occupied"
                }).ToList<object>();
            
        }

        public void UpdateRoom(Room room)
        {
            _room.UpdateRoom(room);
        }
    }
}
