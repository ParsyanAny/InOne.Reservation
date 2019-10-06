using InOne.Reservation.Repository.Repositories;
using InOne.Reservation.Repository.Interfaces;
using InOne.Reservation.Models;
using InOne.Reservation.Tester;
using System;
using System.Collections.Generic;
using System.Linq;
using InOne.Reservation.DataAccess;
using static InOne.Reservation.Models.BookingModel;

namespace InOne.Reservation
{
    class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            ApplicationContext context = new ApplicationContext();
            IUnitOfWork unit = new UnitOfWork(context);

            ///var a = unit.RoomRepository.GetCost(1);
            //Console.WriteLine(a);
            #region Model Test
            #region Booking Test ++
            //var getUserBooks = unit.BookingRepository.GetUserRoomBooks();
            //getUserBooks.PrintUserRoomBook();
            //var searchBy = unit.BookingRepository.SearchBookingBy("N");
            //searchBy.PrintBookings();
            //var res = unit.BookingRepository.SearchBookingBy( "A", 180).ToArray(); +++

            //context.AddRandomBooking(30);
            //context.SaveChanges();
            //context.PrintBookings();
            #endregion

            #region BookingFurniture Test ++
            //context.AddRandomBookingFurnitures(10);
            //context.SaveChanges();
            //context.PrintBookingFurnitures();
            #endregion

            #region Furniture Test ++
            //context.Furnitures.Add(new Furniture { TypeName = "Bed", Price = 12.2m });
            //context.Furnitures.Add(new Furniture { TypeName = "Table", Price = 10m });
            //context.Furnitures.Add(new Furniture { TypeName = "TV", Price = 20.35m });
            //context.Furnitures.Add(new Furniture { TypeName = "Phone", Price = 8.5m });
            //context.Furnitures.Add(new Furniture { TypeName = "Playstation", Price = 25.99m });
            //context.Furnitures.Add(new Furniture { TypeName = "GameBox", Price = 22.22m });
            //context.Furnitures.Add(new Furniture { TypeName = "Piano", Price = 33.3m });
            //context.Furnitures.Add(new Furniture { TypeName = "Bar", Price = 44.4m });
            //context.Furnitures.Add(new Furniture { TypeName = "Sofa", Price = 15 });
            //context.Furnitures.Add(new Furniture { TypeName = "Big Table", Price = 20 });
            //context.Furnitures.Add(new Furniture { TypeName = "Pen", Price = 0.99m });
            //context.Furnitures.Add(new Furniture { TypeName = "Pencil", Price = 0.99m });
            //context.Furnitures.Add(new Furniture { TypeName = "Chair", Price = 5.99m });
            //context.Furnitures.Add(new Furniture { TypeName = "Matras", Price = 6.99m });
            //context.Furnitures.Add(new Furniture { TypeName = "Couch", Price = 6.5m });
            //context.Furnitures.Add(new Furniture { TypeName = "Armchair", Price = 5.99m });
            //context.Furnitures.Add(new Furniture { TypeName = "Big Bed", Price = 29.99m });
            //context.Furnitures.Add(new Furniture { TypeName = "Violin", Price = 15 });
            //context.Furnitures.Add(new Furniture { TypeName = "Cello", Price = 35.5m });
            //context.Furnitures.Add(new Furniture { TypeName = "Easel", Price = 26.99m });
            //context.SaveChanges();
            //context.PrintFurnitures();
            #endregion+

            #region Room Test ++

            //context.AddRandomRooms(80);
            //context.SaveChanges();
            //context.PrintRooms();
            //var res = unit.RoomRepository.GetCost( 2);
            #endregion

            #region RoomFurniture Test ++
            //context.AddRandomRoomFurnitures(10);
            //context.SaveChanges();
            //context.PrintRoomFurnitures();
            #endregion

            #region User Test ++
            //context.AddRandomUsers(100);
            //context.SaveChanges();
            ////var users = unit.UserRepository.GetUsersWithChar('E');
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

            #region UserBooking Test ++
            //context.AddRandomUserBookings(10);
            //context.SaveChanges();
            //context.PrintUserBooking();
            #endregion

            #endregion
            #region QueriesTest

            #region Test UserModel Add,Change,Get
            Console.WriteLine("1");
            UserModel[] um = unit.UserRepository.GetUsers();
            Console.WriteLine("2");
            Console.WriteLine();
            #endregion

            #region Test FurnitureModel Add, Change, Get
            //FurnitureModel fm = new FurnitureModel()
            //{
            //    Name = "Plazma",
            //    Price = 100
            //};
            //unit.FurnitureRepository.AddFurniture(fm);
            //context.PrintFurnitures();

            //FurnitureModel fm = new FurnitureModel()
            //{
            //    Id = 21,
            //    Price = 111,
            //    Name = "Plazma"
            //};
            //unit.FurnitureRepository.ChangeFurniture(fm);

            //context.PrintFurnitures();
            #endregion

            #region Test RoomModel Add,Change,Get
            //List<FurnitureInfo> furs = new List<FurnitureInfo>() { new FurnitureInfo { FurnitureId = 1, FurnitureCount = 1 } };
            //RoomModel rm = new RoomModel()
            //{
            //    IsEmpty = true,
            //    Number = 777,
            //    Price = 77,
            //    Furnitures = furs,
            //    //ParentRoomId
            //};
            //unit.RoomRepository.AddRoom(rm);

            //List<FurnitureInfo> furs = new List<FurnitureInfo>() { new FurnitureInfo { FurnitureId = 1, FurnitureCount = 1 } };
            //RoomModel rm = new RoomModel()
            //{
            //    Id = 104,
            //    IsEmpty = false,
            //    Number = 710,
            //    Price = 666,
            //    Furnitures = furs,
            //    ParentRoomId = 1
            //};
            //unit.RoomRepository.ChangeRoom(rm);

            //RoomModel[] rms = unit.RoomRepository.GetRooms();

            //context.PrintRooms();
            #endregion

            #region Test AddReservation
            //context.PrintRooms();
            //List<int> users = new List<int>() { 2 };
            //List<FurnitureInfo> furs = new List<FurnitureInfo>() { new FurnitureInfo { FurnitureId = 1, FurnitureCount = 1 } };
            //BookingModel bm = new BookingModel
            //{
            //    UserId = 1,
            //    RoomNumber = 66,
            //    StartTime = MyTime.TimeSpans[1],
            //    EndTime = MyTime.TimeSpans[2],
            //    UsersIds = users,
            //    Furnitures = furs
            //};
            //unit.BookingRepository.AddBooking(bm);
            //unit.Commit();
            //context.PrintUsers();
            //Console.WriteLine($"{bm.RoomNumber} {bm.UserId}");
            #endregion

            #endregion
            Console.Read();

        }


        public static IEnumerable<int> GetLengthsOf(string[] words)
            => words.Select(p => p.Length);
    }
}
