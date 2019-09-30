 using System.Data.Entity;
using InOne.Reservation.Repository.Models;
using InOne.Reservation.Repository.Interfaces;
using System.Linq;
using static InOne.Reservation.Repository.Models.UserRoomBook;
using System.Collections.Generic;

namespace InOne.Reservation.Repository.Repositories
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(DbContext context) : base(context) { }
        public void DeleteAllBookings()
        => _context.Set<Booking>().RemoveRange(_context.Set<Booking>().AsQueryable());
        public UserRoomBook[] GetUserRoomBooks()
        {
            var result = from user in _context.Set<User>()
                                    join book in _context.Set<Booking>() on user.Id equals book.User.Id
                                    group book by user into UserGroup
                                    select new UserRoomBook
                                    {
                                        Name = UserGroup.Key.Name,
                                        Surname = UserGroup.Key.Surname,
                                        Balance = UserGroup.Key.Balance,
                                        Bookings = UserGroup.Select(p => new Book { StartTime = p.StartTime, RoomNumber = p.Room.Number })
                                    };
            return result.ToArray();
        }
        public IEnumerable<Booking> SearchBookingBy(string userNameStart)
            => _context.Set<Booking>().Select(p => p).Where(p => p.User.Name.StartsWith(userNameStart)).ToArray();
        public IEnumerable<Booking> SearchBookingBy(string userNameStart, decimal cost)
           =>  _context.Set<Booking>().Select(p => p).Where(p => p.User.Name.StartsWith(userNameStart) && p.Room.Price == (double)cost).ToArray();
    }
}
