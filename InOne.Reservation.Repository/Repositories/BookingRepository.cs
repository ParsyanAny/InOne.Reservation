using System.Data.Entity;
using InOne.Reservation.Repository.Models;
using InOne.Reservation.Repository.Interfaces;
using System.Linq;

namespace InOne.Reservation.Repository.Repositories
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(DbContext context) : base(context) { }
        public void DeleteAllBookings(ApplicationContext context)
        => context.Bookings.RemoveRange(context.Bookings.AsQueryable());
    }
}
