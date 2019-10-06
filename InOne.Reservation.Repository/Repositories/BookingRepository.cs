using InOne.Reservation.Models;
using InOne.Reservation.Repository.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System;
using InOne.Reservation.DataAccess;
using static InOne.Reservation.Models.UserRoomBook;

namespace InOne.Reservation.Repository.Repositories
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationContext context) : base(context) { }

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
        public void AddBooking(BookingModel bookingModel)
        {
            var currentRoom = _context.Rooms.Where(p => p.Number == bookingModel.RoomNumber).FirstOrDefault();

            _context.Bookings.Add(new Booking
            {
                StartTime = bookingModel.StartTime,
                EndTime = bookingModel.EndTime,
                RoomId = currentRoom.Id,
                UserId = bookingModel.UserId,
                BookingFurnitures = bookingModel.Furnitures.Select(p => new BookingFurniture { Count = p.FurnitureCount, FurnitureId = p.FurnitureId }).ToList(),
                UserBookings = bookingModel.UsersIds.Select(p => new UserBooking { UserId = bookingModel.UserId }).ToList()
            });


            var furIds = bookingModel.Furnitures.Select(p => p.FurnitureId).ToList();
            var cost = _context.Furnitures.Where(p => furIds.Contains(p.FurnitureId)).Select(p => new { p.Price, p.FurnitureId }).ToArray();
            decimal furBokCost = (from cos in cost
                                  join furId in bookingModel.Furnitures on cos.FurnitureId equals furId.FurnitureId
                                  select cos.Price * furId.FurnitureCount).Sum();
            var furRomCost = (from fur in _context.Furnitures
                                  join romFur in _context.RoomFurnitures on fur.FurnitureId equals romFur.FurnitureId /*into Furnes
                                  from cs in Furnes.DefaultIfEmpty()*/
                                  where romFur.RoomId == currentRoom.Id
                                  select fur.Price * romFur.Count).Sum();

            decimal furFullCost = furBokCost + furRomCost;

            decimal fullBokCost = currentRoom.Price * (bookingModel.EndTime.Hours - bookingModel.StartTime.Hours) + furFullCost;

            User currentUser = _context.Users.Find(bookingModel.UserId);
            decimal userBalance = _context.Users.Where(p => p.Id == bookingModel.UserId).Select(p => p.Balance).First();

            if (userBalance < Convert.ToDecimal(fullBokCost) && currentUser != null)
                throw new Exception("Not enough money in the account");
            else
                currentUser.Balance -= Convert.ToDecimal(fullBokCost);
        }
    }
}
