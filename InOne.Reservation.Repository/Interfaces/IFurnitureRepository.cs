using InOne.Reservation.Models;

namespace InOne.Reservation.Repository.Interfaces
{
    public interface IFurnitureRepository : IBaseRepository<Furniture>
    {
        void AddFurniture(FurnitureModel model);
        void ChangeFurniture(FurnitureModel model);
        FurnitureModel[] GetFurnitureModels();
        void DeleteAllFurnitures();
    }
}
