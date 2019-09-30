using InOne.Reservation.Repository.Models;

namespace InOne.Reservation.Repository.Interfaces
{
    public interface IRoomRepository : IBaseRepository<Room>
    {
        void DeleteAllRooms();
        double GetCost(int roomID);
    }
}
