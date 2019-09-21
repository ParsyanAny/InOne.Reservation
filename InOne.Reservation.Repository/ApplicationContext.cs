using InOne.Reservation.Repository.Models;
using System.Data.Entity;

namespace InOne.Reservation.Repository
{
    class ApplicationContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingFurniture> BookingFurnitures { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomFurniture> RoomFurnitures { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBooking> UserBookings { get; set; }

        public ApplicationContext() : base(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ReservationDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False") { }
    }
}
