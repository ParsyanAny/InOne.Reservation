using InOne.Reservation.Models;

namespace InOne.Reservation.Manager
{
    public interface IRoomManager : IBaseManager<Room>
    {
        void ChangeRoom(RoomModel model);
        void AddRoom(RoomModel roomModel);
        void DeleteAllRooms();
        decimal GetCost(int roomID);
        Room GetByNumber(int number);
        RoomModel[] GetRooms();
    }
}
