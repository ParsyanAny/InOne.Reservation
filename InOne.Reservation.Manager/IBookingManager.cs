using InOne.Reservation.Models;
using System.Collections.Generic;

namespace InOne.Reservation.Manager
{
    public interface IBookingManager : IBaseManager<Booking>
    {
        void AddBooking(BookingModel model);
        void DeleteAllBookings();
        UserRoomBook[] GetUserRoomBooks();
        IEnumerable<Booking> SearchBookingBy(string userNameStart);
        IEnumerable<Booking> SearchBookingBy(string userNameStart, decimal cost);
    }
}
