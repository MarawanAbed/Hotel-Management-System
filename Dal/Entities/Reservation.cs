using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Entities
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public string CustomerName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public ReservationStatus Status { get; set; }

        public int RoomID { get; set; }
        public Room Room { get; set; }
    }
    public enum ReservationStatus
    {
        Upcoming,
        Ongoing,
        CheckedOut,
        Canceled,
        NoShow
    }
}
