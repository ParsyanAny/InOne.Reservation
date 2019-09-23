using InOne.Reservation.Repository;
using InOne.Reservation.Repository.Interfaces;
using InOne.Reservation.Repository.Models;
using InOne.Reservation.Tester;
using Mic.EFC.Repository.Impl;
using System;
using System.Linq;

namespace InOne.Reservation
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationContext context = new ApplicationContext();
            IUnitOfWork unit = new UnitOfWork(context);
            #region Booking Test +
            //context.AddRandomBooking(50);
            //context.SaveChanges();
            context.PrintBookings();
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
            //context.AddRandomUsers(5);
            //context.SaveChanges();
            //var users = unit.UserRepository.GetUsersWithChar('E');
            //context.PrintUsers();

            //User user = new User { Name = "Any", Surname = "Parsyan", BirthYear = new DateTime(2000, 2, 2)};
            //unit.UserRepository.AddUser(user);
            //unit.Commit();
            //unit.UserRepository.AddUser(user);
            //var users = context.Users.ToArray();
            //unit.UserRepository.DeleteById(2014);
            //unit.Commit();
            //unit.UserRepository.ChangeName("Antonio", "Marcus", 2008);
            //unit.Commit();
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
