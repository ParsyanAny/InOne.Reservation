using InOne.Reservation.DTOModels;
using InOne.Reservation.Models;

namespace InOne.Reservation.Manager
{
    public interface IFurnitureManager : IBaseManager<Furniture, FurnitureDTO>
    {
        void AddFurniture(FurnitureModel model);
        void ChangeFurniture(FurnitureModel model);
        FurnitureModel[] GetFurnitureModels();
        void DeleteAllFurnitures();
    }
}
