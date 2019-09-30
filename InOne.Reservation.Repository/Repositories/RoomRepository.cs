using System.Data.Entity;
using InOne.Reservation.Repository.Models;
using InOne.Reservation.Repository.Interfaces;
using System.Linq;
using static InOne.Reservation.Repository.Models.RoomFurCost;

namespace InOne.Reservation.Repository.Repositories
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(DbContext context) : base(context) { }

        public void DeleteAllRooms()
        => _context.Set<Room>().RemoveRange(_context.Set<Room>().AsQueryable());
        public double GetCost(int roomID)
        {
            //var result = from romfur in context.RoomFurnitures
            //             join rom in context.Rooms on romfur.RoomId equals rom.Id
            //             where rom.Id == roomID
            //             join fur in context.Furnitures on romfur.FurnitureId equals fur.FurnitureId
            //             group fur by rom into RomFurs
            //             select new RoomFurCost
            //             {
            //                 RoomCost = RomFurs.Key.Price,
            //                 FurnituresCost = RomFurs.Select(p => p.Price)
            //             };
            var result = from rom in _context.Set<Room>() where rom.Id == roomID
                         join romfur in _context.Set<RoomFurniture>() on rom.Id equals romfur.RoomId
                         join fur in _context.Set<Furniture>() on romfur.FurnitureId equals fur.FurnitureId
                         group fur by rom into RomFurs
                         select new RoomFurCost
                         {
                             RoomCost = RomFurs.Key.Price,
                             FurnituresCost = RomFurs.Select(p => p.Price)
                         };
            var ar = result.ToArray();
            return result.ToArray().Select(p => p.RoomCost + p.FullFurCost).First();
        }
    }
}