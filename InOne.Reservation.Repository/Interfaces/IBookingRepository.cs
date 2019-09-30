using InOne.Reservation.Repository.Models;
using System.Collections.Generic;

namespace InOne.Reservation.Repository.Interfaces
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        void DeleteAllBookings();
        UserRoomBook[] GetUserRoomBooks();
        IEnumerable<Booking> SearchBookingBy(string userNameStart);
        IEnumerable<Booking> SearchBookingBy(string userNameStart, decimal cost);
    }
}
