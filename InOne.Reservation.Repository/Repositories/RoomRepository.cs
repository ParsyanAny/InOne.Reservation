using System.Data.Entity;
using InOne.Reservation.Repository.Models;
using InOne.Reservation.Repository.Interfaces;
using System.Linq;

namespace InOne.Reservation.Repository.Repositories
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(DbContext context) : base(context) { }

        public void DeleteAllRooms(ApplicationContext context)
        => context.Rooms.RemoveRange(context.Rooms.AsQueryable());
    }
}