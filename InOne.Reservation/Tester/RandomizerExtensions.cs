using System;
using System.Linq;
using InOne.Reservation.Repository;
using InOne.Reservation.Repository.Models;
using static InOne.Reservation.Tester.Enums;

namespace InOne.Reservation.Tester
{
    public static class RandomizerExtensions
    {
        static public Random rand = new Random();

        private static User CreateUser(this User user)
        {
            user.Name = $"{(Names)rand.Next(0, Enum.GetValues(typeof(Names)).Cast<Names>().Distinct().Count())}";
            user.Surname = $"{(Surnames)rand.Next(0, Enum.GetValues(typeof(Surnames)).Cast<Surnames>().Distinct().Count())}";
            user.BirthYear = new DateTime(rand.Next(1920, 2010), rand.Next(1, 12), rand.Next(1, 28));
            return user;
        }
        public static void AddRandomUsers(this ApplicationContext context, int count)
        {
            while (count != 0)
            {
                User user = new User();
                context.Users.Add(user.CreateUser());
                count--;
            }
        }
        private static Room CreateRoom(this ApplicationContext context)
        {
            Room room = new Room();
            int rn = rand.Next(1, 10);
            room.Number = rand.Next(1, 500);
            room.Price = rand.Next(20, 1500) / 3;
            room.IsEmpty = room.Number % 3 + 1 == 0 ? true : false;
            room.ParentRoom = room.Number % 5 == 0 ? context.Rooms.First(p => p.Id % rn == 0) : null;
            room.ParentRoomId = room.ParentRoom?.Id;
            return room;
        }
        public static void AddRandomRooms(this ApplicationContext context, int count)
        {
            while (count != 0)
            {
                context.Rooms.Add(context.CreateRoom());
                count--;
            }
        }
        private static Booking CreateBooking(this Booking reservation)
        {
            reservation.RoomId = rand.Next(0, 500);
            reservation.UserId = rand.Next(0, 49);
            reservation.StartTime = MyTime.TimeSpans[rand.Next(0, 23)];
            reservation.EndTime = MyTime.TimeSpans[rand.Next(0, 23)];
            if (reservation.RoomId % 3 == 0)
            {
                reservation.Time1 = Convert.ToDateTime(reservation.StartTime.Minutes + rand.Next(0,59));
                reservation.Time2 = Convert.ToDateTime(reservation.EndTime.Minutes - rand.Next(0,10));
            }
            return reservation;
        }
        public static void AddRandomBooking(this ApplicationContext context, int count)
        {
            while (count != 0)
            {
                Booking reservation = new Booking();
                context.Bookings.Add(reservation.CreateBooking());
                count--;
            }
        }

        private static BookingFurniture CreateBookingFurniture(this BookingFurniture resfur)
        {
            resfur.FurnitureId = rand.Next(1, 19);
            resfur.BookingId = rand.Next(0, 50);
            resfur.Count = rand.Next(1, 10);
            return resfur;
        }
        public static void AddRandomBookingFurnitures(this ApplicationContext context, int count)
        {
            while (count != 0)
            {
                BookingFurniture resfur = new BookingFurniture();
                context.BookingFurnitures.Add(resfur.CreateBookingFurniture());
                count--;
            }
        }
        private static UserBooking CreateUserBooking(this UserBooking userFur)
        {
            userFur.UserId = rand.Next(0,500);
            userFur.BookingId = rand.Next(0,50);
            return userFur;
        }
        public static void AddRandomUserBookings(this ApplicationContext context, int count)
        {
            while (count != 0)
            {
                UserBooking userBooks = new UserBooking();
                context.UserBookings.Add(userBooks.CreateUserBooking());
                count--;
            }
        }
        private static RoomFurniture CreateRoomFurniture(this RoomFurniture roomfur)
        {
            roomfur.RoomId = rand.Next(0, 500);
            roomfur.FurnitureId = rand.Next(1, 19);
            roomfur.Count = rand.Next(0, 10);
            return roomfur;
        }
        public static void AddRandomRoomFurnitures(this ApplicationContext context, int count)
        {
            while (count != 0)
            {
                RoomFurniture roomFurniture = new RoomFurniture();
                context.RoomFurnitures.Add(roomFurniture.CreateRoomFurniture());
                count--;
            }
        }
    }
}
