using InOne.Reservation.DTOModels;
using InOne.Reservation.Models;
using System.Collections.Generic;

namespace InOne.Reservation.Manager
{
    public interface IUserManager : IBaseManager<User, UserDTO>
    {
        void DeleteAllUsers();
        void AddUser(User user);
        void AddUser(UserModel model);
        void ChangeName(string Name, string Surname, int id);
        void ChangeLogin(string UserName, string Password, int id);
        void ChangeBalance(decimal Balance, int id);
        void ChangeUser(UserModel model);
        IEnumerable<User> GetUsersWithChar(char firstInitial);
        UserModel[] GetUsers();
    }
}
