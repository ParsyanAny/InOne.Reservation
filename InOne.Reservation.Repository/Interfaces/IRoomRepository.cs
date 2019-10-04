using InOne.Reservation.Models;

namespace InOne.Reservation.Repository.Interfaces
{
    public interface IRoomRepository : IBaseRepository<Room>
    {
        void DeleteAllRooms();
        double GetCost(int roomID);
        Room GetByNumber(int number);
    }
}
