using InOne.Reservation.Models;

namespace InOne.Reservation.Manager
{
    public interface IFurnitureManager : IBaseManager<Furniture>
    {
        void AddFurniture(FurnitureModel model);
        void ChangeFurniture(FurnitureModel model);
        FurnitureModel[] GetFurnitureModels();
        void DeleteAllFurnitures();
    }
}
