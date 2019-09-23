using InOne.Reservation.Repository.Models;
using System.Collections.Generic;

namespace InOne.Reservation.Repository.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        void DeleteAllUsers(ApplicationContext context);
        void AddUser(User user);
        void ChangeName(string Name, string Surname, int id);
        IEnumerable<User> GetUsersWithChar(char firstInitial);
    }
}
