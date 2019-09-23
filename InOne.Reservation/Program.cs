using InOne.Reservation.Repository;
using InOne.Reservation.Repository.Models;
using InOne.Reservation.Tester;
using System;
using System.Linq;

namespace InOne.Reservation
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationContext context = new ApplicationContext();

            #region Booking Test +
            //context.AddRandomBooking(50);
            //context.SaveChanges();
            //context.PrintBookings();
            #endregion

            #region BookingFurniture Test +
            //context.AddRandomBookingFurnitures(10);
            //context.SaveChanges();
            //context.PrintBookingFurnitures();
            #endregion

            #region Furniture Test +
            //context.PrintFurnitures();
            #endregion

            #region Room Test +
            //context.AddRandomRooms(100);
            //context.SaveChanges();
            //context.PrintRooms();
            #endregion

            #region RoomFurniture Test +
            //context.AddRandomRoomFurnitures(10);
            //context.SaveChanges();
            //context.PrintRoomFurnitures();
            #endregion

            #region User Test +
            //context.AddRandomUsers(50);
            //context.SaveChanges();
            //context.PrintUsers();
            #endregion

            #region UserBooking Test +
            //context.AddRandomUserBookings(20);
            //context.SaveChanges();
            //context.PrintUserBooking();
            #endregion

            Console.Read();
        }
    }
}
