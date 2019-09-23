using InOne.Reservation.Repository;
using InOne.Reservation.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InOne.Reservation.Tester
{
    public static class PrintExtensions
    {
        public static void PrintFurnitures(this ApplicationContext context)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ID\tName - Price\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in context.Furnitures)
                Console.WriteLine($"{item.FurnitureId}\t{item.TypeName} - {item.Price}$");
            Console.ResetColor();
        }
        public static void PrintUsers(this ApplicationContext context)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ID\tFullname \t\tAge\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var item in context.Users)
                Console.WriteLine($"{item.Id} \t{item.FullName}    \t{item.Adult}");
            Console.ResetColor();
        }
        public static void PrintRooms(this ApplicationContext context)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ID\tNumber\tPrice\tParentRoom ID\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            foreach (var item in context.Rooms)
                Console.WriteLine($"{item.Id}\t{item.Number}\t{item.Price}$\t{item.ParentRoomId}");
            Console.ResetColor();
        }
        public static void PrintBookings(this ApplicationContext context)
        {
            var result = from book in context.Bookings
                         join user in context.Users on book.UserId equals user.Id
                         join room in context.Rooms on book.RoomId equals room.Id
                         select new
                         {
                             BookingId = book.BookingId,
                             UserName = user.Name,
                             UserSurName = user.Surname,
                             RoomNumber = room.Number,
                             RoomPrice = room.Price
                         };

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Id\tUser\t\t\tRoom\tPrice ($)\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var item in result)
            {
                Console.WriteLine($"{item.BookingId}\t{item.UserName} {item.UserSurName}   \t{item.RoomNumber}\t{item.RoomPrice}$");
            }
            Console.ResetColor();
        }
        public static void PrintBookingFurnitures(this ApplicationContext context)
        {
            var result = from bokfur in context.BookingFurnitures
                         join fur in context.Furnitures on bokfur.FurnitureId equals fur.FurnitureId
                         join bok in context.Bookings on bokfur.BookingId equals bok.BookingId
                         select new
                         {
                             bok.BookingId,
                             FurnitureName = fur.TypeName,
                             bokfur.Count,
                             Price = fur.Price * bokfur.Count
                         };

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("BookingId\tFurniture\t\t Price (Count)\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var item in result)
                Console.WriteLine($"{item.BookingId}\t\t{item.FurnitureName}      \t\t {item.Price}$ (x{item.Count})");
            Console.ResetColor();
        }
        public static void PrintRoomFurnitures(this ApplicationContext context)
        {
            var result = from romfur in context.RoomFurnitures
                         join rom in context.Rooms on romfur.RoomId equals rom.Id
                         join fur in context.Furnitures on romfur.FurnitureId equals fur.FurnitureId
                         select new
                         {
                             RoomNumber = rom.Number,
                             Furniture = fur.TypeName,
                             romfur.Count,
                             FullPrice = rom.Price + (fur.Price * romfur.Count)
                         };
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("RoomNumber\tFurniture\t\tPrice (Room * x(furniture))\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var item in result)
                Console.WriteLine($"{item.RoomNumber}\t\t{item.Furniture}    \t\t{item.FullPrice}.00 $");
            Console.ResetColor();
        }
        public static void PrintUserBooking(this ApplicationContext context)
        {
            var userBooking = from userbok in context.UserBookings
                         join user in context.Users on userbok.UserId equals user.Id
                         join bok in context.Bookings on userbok.BookingId equals bok.BookingId
                         select new
                         {
                             bok.BookingId,
                             UserName = user.Name,
                             UserSurname = user.Surname,
                             bok.StartTime,
                             bok.EndTime
                         };
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("BookingId\tCustomer\t\tTime\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var item in userBooking)
                Console.WriteLine($"{item.BookingId}\t\t{item.UserName} {item.UserSurname}    \t{item.StartTime.Hours}.00 - {item.EndTime.Hours}.00");
            Console.ResetColor();
        }
        public static void PrintUsers(this IEnumerable<User> users)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ID\tFullname \t\tAge\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var item in users)
                Console.WriteLine($"{item.Id} \t{item.FullName}    \t{item.Adult}");
            Console.ResetColor();
        }
    }
}
