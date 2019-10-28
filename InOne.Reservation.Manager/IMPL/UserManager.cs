using System.Linq;
using System.Collections.Generic;
using System;
using InOne.Reservation.DataAccess;
using InOne.Reservation.Models;
using InOne.Reservation.DTOModels;

namespace InOne.Reservation.Manager.IMPL
{
    public class UserManager : BaseManager<User, UserDTO>, IUserManager
    {
        public UserManager(ApplicationContext context) : base(context) { }

        public void AddUser(User user)
        {
            if (user.Name != null && user.Name.Length > 2 && user.Surname != null && user.Surname.Length > 3)
                _context.Users.Add(user);
            else
                throw new Exception("Can't Add User with this Name or Surname");
        }
        public void AddUser(UserModel model)
        {
            User user = new User()
            {
                Id = 0,
                Name = model.Name,
                Surname = model.Surname,
                Balance = model.Balance,
                BirthYear = model.BirthYear,
                UserName = model.UserName,
                Password = model.Password,
                UserBookings = model.FriendsIds.Select(p => new UserBooking
                { UserId = p }).ToList()
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            User currentUser = _context.Users.Where(p => p.UserName == model.UserName).First();
            model.Id = currentUser.Id;
        }
        public void ChangeUser(UserModel model)
        {
            var result = _context.Users.Find(model.Id);
            if (result != null)
            {
                result.Name = model.Name;
                result.Surname = model.Surname;
                result.UserName = model.UserName;
                result.Password = model.Password;
                result.Balance = model.Balance;
                result.BirthYear = model.BirthYear;
                result.UserBookings = model.FriendsIds.Select(p => new UserBooking
                { UserId = p }).ToList();
            }
        }
        public void ChangeName(string Name, string Surname, int id)
        {
            var result = _context.Users.Find(id);
            if (result != null)
            {
                result.Name = Name;
                result.Surname = Surname;
            }
        }
        public void ChangeLogin(string UserName, string Password, int id)
        {
            var result = _context.Users.Find(id);
            if (result != null)
            {
                result.UserName = UserName;
                result.Password = Password;
            }
        }
        public void ChangeBalance(decimal Balance, int id)
        {
            var result = _context.Users.Find(id);
            if (result != null)
                result.Balance = Balance;
        }
        public void DeleteAllUsers()
        => _context.Users.RemoveRange(_context.Users.AsQueryable());
        public IEnumerable<User> GetUsersWithChar(char firstInitial)
        {
            string ini = firstInitial.ToString();
            return _context.Users.Select(p => p).Where(p => p.Name.StartsWith(ini));
        }
        public UserModel[] GetUsers()
        {
            var userModels = _context.Users.Select(p => new UserModel
            {
                Id = p.Id,
                Name = p.Name,
                Surname = p.Surname,
                Balance = p.Balance,
                BirthYear = p.BirthYear,
                UserName = p.UserName,
                Password = p.Password,
                FriendsIds = p.UserBookings.Select(u => u.UserId).ToList()
            });
            return userModels.ToArray();
        }

        public override UserDTO ModelToDto(User model)
            => new UserDTO
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Balance = model.Balance,
                BirthYear = model.BirthYear,
                UserName = model.UserName,
                Password = model.Password

            };
        public override User DtoToModel(UserDTO dto)
            => new User
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                BirthYear = dto.BirthYear,
                Balance = dto.Balance,
                UserName = dto.UserName,
                Password = dto.Password

            };
    }
}
