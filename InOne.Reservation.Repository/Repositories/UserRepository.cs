using InOne.Reservation.Repository.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System;
using InOne.Reservation.DataAccess;
using InOne.Reservation.Models;

namespace InOne.Reservation.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context) { }

        public void AddUser(User user)
        {
            if (user.Name != null && user.Name.Length > 2 && user.Surname != null && user.Surname.Length > 3)
                _context.Users.Add(user);
            else
                throw new Exception("Can't Add User with this Name or Surname");
        }

        public void ChangeName(string Name, string Surname, int id)
        {
                var result = _context.Users.SingleOrDefault(user => user.Id == id);
                if (result != null)
                {
                    result.Name = Name;
                    result.Surname = Surname;
                }
        }
        public void ChangeLogin(string UserName, string Password, int id)
        {
            var result = _context.Users.SingleOrDefault(user => user.Id == id);
            if (result != null)
            {
                result.UserName = UserName;
                result.Password = Password;
            }
        }
        public void ChangeBalance(decimal Balance, int id)
        {
            var result = _context.Users.SingleOrDefault(user=> user.Id == id);
            if (result != null)
                result.Balance = Balance;
        }
        public void DeleteAllUsers()
        => _context.Users.RemoveRange(_context.Set<User>().AsQueryable());
        public IEnumerable<User> GetUsersWithChar(char firstInitial)
        {
            string ini = firstInitial.ToString();
            return _context.Users.Select(p => p).Where(p => p.Name.StartsWith(ini));
        }
    }
}
