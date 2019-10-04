using InOne.Reservation.Models;

namespace InOne.Reservation.Repository.Interfaces
{
    public interface IFurnitureRepository : IBaseRepository<Furniture>
    {
        void DeleteAllFurnitures();
    }
}
