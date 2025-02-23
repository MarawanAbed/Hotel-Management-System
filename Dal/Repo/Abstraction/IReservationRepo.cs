using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repo.Abstraction
{
    public interface IReservationRepo
    {
        public List<Reservation> GetAll();
        public List<Reservation> GetAllReservations();
        public List<Room> GetAvailableRooms();
        public Reservation GetReservationById(int id);
        public Room GetRoomById(int id);
        public void AddReservation(Reservation reservation);
        public void UpdateReservation(Reservation reservation);
        public void DeleteReservation(int id);
        public void AddREservationRange(List<Reservation> ReservationList);
    }
}
