using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repo.Abstraction
{
    public interface IRoomRepo
    {
        public List<Room> GetAll();
        List<Room> GetAllRooms();
        void AddRoom(Room room);
        void UpdateRoom(Room room);
        void DeleteRoom(int roomId);
        Room GetRoomById(int roomId);
    }
}
