using System.Data.Entity;
using InOne.Reservation.Repository.Models;
using InOne.Reservation.Repository.Interfaces;
using System.Linq;

namespace InOne.Reservation.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }

        public void DeleteAllUsers(ApplicationContext context)
        => context.Users.RemoveRange(context.Users.AsQueryable());
    }
}
