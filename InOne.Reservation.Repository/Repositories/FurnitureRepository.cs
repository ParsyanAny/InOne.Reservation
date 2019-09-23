using System.Data.Entity;
using InOne.Reservation.Repository.Models;
using InOne.Reservation.Repository.Interfaces;
using System.Linq;

namespace InOne.Reservation.Repository.Repositories
{
    public class FurnitureRepository : BaseRepository<Furniture>, IFurnitureRepository
    {
        public FurnitureRepository(DbContext context) : base(context) { }
        public void DeleteAllFurnitures(ApplicationContext context)
             => context.Furnitures.RemoveRange(context.Furnitures.AsQueryable());
    }
}