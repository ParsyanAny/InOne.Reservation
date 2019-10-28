using InOne.Reservation.DTOModels;
using InOne.Reservation.Models;
using System.Collections.Generic;

namespace InOne.Reservation.Manager
{
    public interface IBookingManager : IBaseManager<Booking, BookingDTO>
    {
        void AddBooking(BookingModel model);
        void DeleteAllBookings();
        UserRoomBook[] GetUserRoomBooks();
        IEnumerable<Booking> SearchBookingBy(string userNameStart);
        IEnumerable<Booking> SearchBookingBy(string userNameStart, double cost);
    }
}
