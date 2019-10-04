using InOne.Reservation.DataAccess;
using InOne.Reservation.Models;
using InOne.Reservation.Repository.Interfaces;
using System.Linq;

namespace InOne.Reservation.Repository.Repositories
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(ApplicationContext context) : base(context) { }

        public void DeleteAllRooms()
        => _context.Rooms.RemoveRange(_context.Rooms.AsQueryable());

        public Room GetByNumber(int number)
            => _context.Rooms.Where(p => p.Number == number).FirstOrDefault();
        public double GetCost(int roomID)
        {
            throw new System.Exception();
            ////var result = from romfur in context.RoomFurnitures
            ////             join rom in context.Rooms on romfur.RoomId equals rom.Id
            ////             where rom.Id == roomID
            ////             join fur in context.Furnitures on romfur.FurnitureId equals fur.FurnitureId
            ////             group fur by rom into RomFurs
            ////             select new RoomFurCost
            ////             {
            ////                 RoomCost = RomFurs.Key.Price,
            ////                 FurnituresCost = RomFurs.Select(p => p.Price)
            ////             };
            //var result = from rom in _context.Rooms where rom.Id == roomID
            //             join romfur in _context.RoomFurnitures on rom.Id equals romfur.RoomId
            //             join fur in _context.Furnitures on romfur.FurnitureId equals fur.FurnitureId
            //             group fur by rom into RomFurs
            //             select new RoomFurCost
            //             {
            //                 RoomCost = RomFurs.Key.Price,
            //                 FurnituresCost = RomFurs.Select(p => p.Price)
            //             };
            //var ar = result.ToArray();
            //return result.ToArray().Select(p => p.RoomCost + p.FullFurCost).First();
        }
    }
}