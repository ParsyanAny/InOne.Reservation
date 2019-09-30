using System;
using System.Collections.Generic;

namespace InOne.Reservation.Repository.Models
{
    public class UserRoomBook
    {
        public class Book
        {
            public TimeSpan StartTime { get; set; }
            public int RoomNumber { get; set; }
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Balance { get; set; }
        public IEnumerable<Book> Bookings { get; set; }
       
    }
}
 