using BL.Services.Abstraction;
using Dal.Entities;
using Dal.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Implementation
{
    public class ReservationServices : IReservationServices
    {
        private readonly IReservationRepo _reservationRepo;

        public ReservationServices(IReservationRepo reservationRepo)
        {
            _reservationRepo = reservationRepo;
        }
        public void AddReservation(Reservation reservation)
        {
            Reservation newReservation = new Reservation
            {
                CustomerName = reservation.CustomerName,
                RoomID = reservation.RoomID,
                CheckInDate = reservation.CheckInDate,
                CheckOutDate = reservation.CheckOutDate,
                Status = ReservationStatus.Upcoming
            };

            _reservationRepo.AddReservation(newReservation);
        }

        public void DeleteReservation(int id)
        {
            _reservationRepo.DeleteReservation(id);
        }

        public List<Object> GetAllReservations()
        {

            var reservations = _reservationRepo.GetAllReservations();
            return reservations.Select(r => new
            {
                r.ReservationID,
                r.CustomerName,
                RoomNumber = r.Room?.RoomNumber,
                r.CheckInDate,
                r.CheckOutDate,
                Status = r.Status.ToString()
            }).ToList<object>();

        }

        public List<Room> GetAvailableRooms()
        {
            return _reservationRepo.GetAvailableRooms();
        }

        public Reservation GetReservationById(int id)
        {

            return _reservationRepo.GetReservationById(id);
        }

        public Reservation GetRoomById(int id)
        {

            return _reservationRepo.GetReservationById(id);
        }

        public void UpdateReservation(Reservation reservations)
        {
            var reservation = _reservationRepo.GetReservationById(reservations.ReservationID);
            if (reservation != null)
            {
                reservation.CustomerName = reservations.CustomerName;
                reservation.RoomID = reservations.RoomID;
                reservation.CheckInDate = reservations.CheckInDate;
                reservation.CheckOutDate = reservations.CheckOutDate;
                reservation.Status = reservations.Status;

                _reservationRepo.UpdateReservation(reservation);
            }
        }

        Room IReservationServices.GetRoomById(int id)
        {
            return _reservationRepo.GetRoomById(id);
        }
    }
}
