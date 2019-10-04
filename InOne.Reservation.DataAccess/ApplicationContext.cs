using InOne.Reservation.Models;
using System.Data.Entity;

namespace InOne.Reservation.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingFurniture> BookingFurnitures { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomFurniture> RoomFurnitures { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBooking> UserBookings { get; set; }

        public ApplicationContext() : base("ConString") { }
        //public ApplicationContext() : base(@"Data Source = Any; Initial Catalog = ReservationDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False") { }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //}
    }
}
