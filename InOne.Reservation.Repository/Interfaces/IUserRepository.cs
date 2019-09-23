using InOne.Reservation.Repository.Models;

namespace InOne.Reservation.Repository.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        void DeleteAllUsers(ApplicationContext context);
    }
}
