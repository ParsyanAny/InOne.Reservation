using InOne.Reservation.Models;
using System.Collections.Generic;

namespace InOne.Reservation.Repository.Interfaces
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        void AddBooking(BookingModel model);
        void DeleteAllBookings();
        UserRoomBook[] GetUserRoomBooks();
        IEnumerable<Booking> SearchBookingBy(string userNameStart);
        IEnumerable<Booking> SearchBookingBy(string userNameStart, decimal cost);
    }
}
