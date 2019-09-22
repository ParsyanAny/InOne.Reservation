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
            ApplicationContext app = new ApplicationContext();
            //app.AddRandomRooms(50);
            //app.Furnitures.Add(new Furniture {TypeName = "Table", Price = 10 });
            //app.Rooms.Add(new Room { Number = 1, Price = 10, IsEmpty = true });
            //app.RoomFurnitures.Add(new RoomFurniture { FurnitureId = 1, RoomId = 1, Count = 2});
            //app.Furnitures.ToArray().PrintFurnitures();
            app.Rooms.ToArray().PrintRooms();
            Console.Read();
        }
    }
}
