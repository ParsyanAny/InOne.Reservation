using InOne.Reservation.Repository.Models;

namespace InOne.Reservation.Repository.Interfaces
{
    public interface IFurnitureRepository : IBaseRepository<Furniture>
    {
        void DeleteAllFurnitures(ApplicationContext context);
    }
}
