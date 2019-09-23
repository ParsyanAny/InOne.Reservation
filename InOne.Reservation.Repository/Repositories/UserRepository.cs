using System.Data.Entity;
using InOne.Reservation.Repository.Models;
using InOne.Reservation.Repository.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System;

namespace InOne.Reservation.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }

        public void AddUser(User user)
        {
            if (user.Name != null && user.Name.Length > 2 && user.Surname != null && user.Surname.Length > 3)
                _context.Set<User>().Add(user);
            else
                throw new Exception("Can't Add User with this Name or Surname");
        }

        public void ChangeName(string Name, string Surname, int id)
        {
                var result = _context.Set<User>().SingleOrDefault(b => b.Id == id);
                if (result != null)
                {
                    result.Name = Name;
                    result.Surname = Surname;
                }
        }

        public void DeleteAllUsers(ApplicationContext context)
        => context.Users.RemoveRange(context.Users.AsQueryable());

        public IEnumerable<User> GetUsersWithChar(char firstInitial)
        {
            string ini = firstInitial.ToString();
            return _context.Set<User>().Select(p => p).Where(p => p.Name.StartsWith(ini));
        }
    }
}
