using InOne.Reservation.DataAccess;
using InOne.Reservation.Models;
using InOne.Reservation.Repository.Interfaces;
using System.Linq;

namespace InOne.Reservation.Repository.Repositories
{
    public class FurnitureRepository : BaseRepository<Furniture>, IFurnitureRepository
    {
        public FurnitureRepository(ApplicationContext context) : base(context) { }

        public void AddFurniture(FurnitureModel model)
        {
            Furniture furniture = new Furniture()
            {
                FurnitureId = 0,
                Price = model.Price,
                TypeName = model.Name
            };
            _context.Furnitures.Add(furniture);
            _context.SaveChanges();
            Furniture currentFur = _context.Furnitures.Where(p => p.TypeName == model.Name).First();
            model.Id = currentFur.FurnitureId;
        }
        public void ChangeFurniture(FurnitureModel model)
        {
            var result = _context.Furnitures.Find(model.Id);
            if (result != null)
            {
                result.Price = model.Price;
                result.TypeName = model.Name;
                result.TypeName = model.Name ?? result.TypeName;
            }
        }
        public void DeleteAllFurnitures()
             => _context.Furnitures.RemoveRange(_context.Furnitures.AsQueryable());
        public FurnitureModel[] GetFurnitureModels()
        {
            FurnitureModel[] furnitureModels = _context.Furnitures.Select(p => new FurnitureModel
            {
                Id = p.FurnitureId,
                Name = p.TypeName,
                Price = p.Price
            }).ToArray();
            return furnitureModels;
        }
    }
}