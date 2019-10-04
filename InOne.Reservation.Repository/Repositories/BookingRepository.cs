using InOne.Reservation.Models;
using InOne.Reservation.Repository.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System;
using static InOne.Reservation.Models.UserRoomBook;
using InOne.Reservation.DataAccess;

namespace InOne.Reservation.Repository.Repositories
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationContext context) : base(context) { }

        public void AddBooking(BookingModel bookingModel)
        {
            var room = _context.Rooms.Where(p => p.Number == bookingModel.RoomNumber).FirstOrDefault();
            _context.Bookings.Add(new Booking
            {
                StartTime = bookingModel.StartTime,
                EndTime = bookingModel.EndTime,
                RoomId = room.Id,
                UserId = bookingModel.UserId,
                BookingFurnitures = bookingModel.Furnitures.Select(p => new BookingFurniture { Count = p.FurnitureCount, FurnitureId = p.FurnitureId }).ToList(),
                UserBookings = bookingModel.UsersIds.Select(p => new UserBooking { UserId = bookingModel.UserId }).ToList()
            });

            var furCount = from fur in _context.Furnitures
                           join furbok in _context.BookingFurnitures on fur.FurnitureId equals furbok.FurnitureId
                           group fur by furbok into Furs 
                           select new
                           {
                               Furs.Key.Count,
                               Furniture = Furs.Select(p=> p.FurnitureId),
                               Price = Furs.Select(p=> p.Price)
                           };

            var furIds = bookingModel.Furnitures.Select(p => p.FurnitureId).ToList();
            var furs = _context.Furnitures.Where(p => furIds.Contains(p.FurnitureId)).Select(p => new { p.Price, p.RoomFurniture.Count }).ToList();

            var getCost = (room.Price + 0) * (bookingModel.EndTime.Hours - bookingModel.StartTime.Hours);
            var result = _context.Users.SingleOrDefault(user => user.Id == bookingModel.UserId);
            if (result != null)
                result.Balance -= Convert.ToDecimal(getCost);
        }
        public void DeleteAllBookings()
        => _context.Set<Booking>().RemoveRange(_context.Set<Booking>().AsQueryable());
        public UserRoomBook[] GetUserRoomBooks()
        {
            var result = from user in _context.Users
                         join book in _context.Bookings on user.Id equals book.User.Id
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
            => _context.Bookings.Select(p => p).Where(p => p.User.Name.StartsWith(userNameStart)).ToArray();
        public IEnumerable<Booking> SearchBookingBy(string userNameStart, decimal cost)
           => _context.Bookings.Select(p => p).Where(p => p.User.Name.StartsWith(userNameStart) && p.Room.Price == cost).ToArray();
    }
}
