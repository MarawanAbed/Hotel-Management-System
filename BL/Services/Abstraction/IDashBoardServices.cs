using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Abstraction
{
    public interface IDashBoardServices
    {
        int GetTotalEmployees();
        int GetAvailableRooms();
        int GetOccupiedRooms();
        int GetUpcomingReservations();
        List<object> GetRecentReservations();
    }
}
