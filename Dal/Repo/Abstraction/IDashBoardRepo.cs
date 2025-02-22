using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repo.Abstraction
{
    public interface IDashBoardRepo
    {
        int GetTotalEmployees();
        int GetAvailableRooms();
        int GetOccupiedRooms();
        int GetUpcomingReservations();
        List<object> GetRecentReservations();
    }
}
