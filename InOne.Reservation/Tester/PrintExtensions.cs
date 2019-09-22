﻿using InOne.Reservation.Repository.Models;
using System;
using System.Collections.Generic;

namespace InOne.Reservation.Tester
{
    public static class PrintExtensions
    {
        public static void PrintFurnitures(this IEnumerable<Furniture> furniture)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ID\tTypename - Price\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var item in furniture)
            {
                Console.WriteLine($"{item.FurnitureId}\t{item.TypeName} - {item.Price}$");
            }
            Console.ResetColor();
        }
        public static void PrintUsers(this IEnumerable<User> users)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ID\tFullname \t\tAge\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var item in users)
                Console.WriteLine($"{item.Id} \t{item.FullName}    \t\t{item.Adult} ({item.Age})");
            Console.ResetColor();
        }
        public static void PrintRooms(this IEnumerable<Room> rooms)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ID\tNumber\tPrice\tParentRoom Id");
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var item in rooms)
            {
                Console.WriteLine($"{item.Id}\t{item.Number}\t{item.Price}$\t{item.ParentRoomId}");
            }
            Console.ResetColor();
        }
        public static void PrintBookings(this IEnumerable<Booking> reservations)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ID\tUserID\tRoomID");
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var item in reservations)
            {
                Console.WriteLine($"{item.BookingId}\t{item.UserId}\t{item.RoomId}");
            }
            Console.ResetColor();
        }
        public static void PrintBookingFurnitures(this IEnumerable<BookingFurniture> resfurs)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("FurnitureID BookingID FurnitureCount");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            foreach (var item in resfurs)
            {
                Console.WriteLine($"{item.FurnitureId}\t    {item.BookingId}\t\t  {item.Count}");
            }
            Console.ResetColor();
        }
        public static void PrintRoomFurnitures(this IEnumerable<RoomFurniture> roomfurs)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ID\tRoomID   FurnitureID    Count");
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var item in roomfurs)
            {
                Console.WriteLine($"{item.RoomId}\t{item.FurnitureId}\t\t{item.Count}");
            }
            Console.ResetColor();
        }
    }
}
