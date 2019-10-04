using InOne.Reservation.DataAccess;
using InOne.Reservation.Models;
using InOne.Reservation.Repository.Interfaces;
using System.Linq;

namespace InOne.Reservation.Repository.Repositories
{
    public class FurnitureRepository : BaseRepository<Furniture>, IFurnitureRepository
    {
        public FurnitureRepository(ApplicationContext context) : base(context) { }
        public void DeleteAllFurnitures()
             => _context.Furnitures.RemoveRange(_context.Furnitures.AsQueryable());
    }
}