using BL.Services.Abstraction;
using Dal.Repo.Abstraction;


namespace BL.Services.Implementation
{
    public class DashBoardServices : IDashBoardServices
    {
        private readonly IDashBoardRepo _dashBoard;

        public DashBoardServices(IDashBoardRepo dashBoard)
        {
            _dashBoard = dashBoard;
        }

        public int GetAvailableRooms()
        {
            return _dashBoard.GetAvailableRooms();
        }

        public int GetOccupiedRooms()
        {
            return _dashBoard.GetOccupiedRooms();
        }

        public List<object> GetRecentReservations()
        {
            return _dashBoard.GetRecentReservations();
        }

        public int GetTotalEmployees()
        {
            return _dashBoard.GetTotalEmployees();
        }

        public int GetUpcomingReservations()
        {
            return _dashBoard.GetUpcomingReservations();
        }
    }
}
