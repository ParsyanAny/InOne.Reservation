using InOne.Reservation.Repository.Models;
using System;
using System.Linq;
using static InOne.Reservation.Tester.MockNames.Enums;

namespace InOne.Reservation.Tester.Extensions
{ 
    public static class CreateRandomEntities
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
        private static Reservation CreateReservation(this Reservation reservation)
        {
            reservation.ReservationTimeId = rand.Next(1, 24);
            reservation.RoomId = rand.Next(100, 500);
            reservation.UserId = rand.Next(0, 500);
            return reservation;
        }
        public static void AddRandomReservations(this ApplicationContext context, int count)
        {
            while (count != 0)
            {
                Reservation reservation = new Reservation();
                context.Reservations.Add(reservation.CreateReservation());
                count--;
            }
        }
        private static ReservationFurniture CreateReservationFurniture(this ReservationFurniture resfur)
        {
            resfur.FurnitureId = rand.Next(0, 50);
            resfur.ReservationId = rand.Next(0, 50);
            resfur.Count = rand.Next(1, 10);
            return resfur;
        }
        public static void AddRandomReservationFurnitures(this ApplicationContext context, int count)
        {
            while (count != 0)
            {
                ReservationFurniture resfur = new ReservationFurniture();
                context.ReservationFurnitures.Add(resfur.CreateReservationFurniture());
                count--;
            }
        }
        private static RoomFurniture CreateRoomFurniture(this RoomFurniture roomfur)
        {
            roomfur.ReservationId = rand.Next(0, 20);
            roomfur.FurnitureId = rand.Next(0, 30);
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
