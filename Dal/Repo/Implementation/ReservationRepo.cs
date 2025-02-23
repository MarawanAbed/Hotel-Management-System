using Dal.Entities;
using Dal.Repo.Abstraction;
using HotelManagementSystem.database;
using Microsoft.EntityFrameworkCore;


namespace Dal.Repo.Implementation
{


    public class ReservationRepo : IReservationRepo
    {
        private readonly ApplicationDbContext _context;

        public ReservationRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            var room = _context.Rooms.Find(reservation.RoomID);


            _context.SaveChanges();
        }

        public void AddREservationRange(List<Reservation> ReservationList)
        {
             _context.Reservations.AddRange(ReservationList);
            _context.SaveChanges();
        }

        public void DeleteReservation(int id)
        {
            var reservation = _context.Reservations.Find(id);
            if (reservation != null)
            {
                var room = _context.Rooms.Find(reservation.RoomID);
                if (room != null)
                {
                    room.Availability = true;
                }

                _context.Reservations.Remove(reservation);
                _context.SaveChanges();
            }
        }

        public List<Reservation> GetAll()
        {
            return _context.Reservations.ToList();
        }

        public List<Reservation> GetAllReservations()
        {
            return _context.Reservations
                .Include(r => r.Room) 
                .ToList();
        }

        public List<Room> GetAvailableRooms()
        {
            return _context.Rooms.Where(r => r.Availability).ToList();
        }

        public Reservation GetReservationById(int id)
        {
            return _context.Reservations.Find(id);
        }

        public Room GetRoomById(int id)
        {
            return _context.Rooms.Find(id);
        }

        public void UpdateReservation(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            _context.SaveChanges();
        }
    }
}
