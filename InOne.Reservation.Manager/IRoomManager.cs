using InOne.Reservation.DTOModels;
using InOne.Reservation.Models;

namespace InOne.Reservation.Manager
{
    public interface IRoomManager : IBaseManager<Room,RoomDTO>
    {
        void ChangeRoom(RoomModel model);
        void AddRoom(RoomModel roomModel);
        void DeleteAllRooms();
        double GetCost(int roomID);
        Room GetByNumber(int number);
        RoomModel[] GetRooms();
    }
}
