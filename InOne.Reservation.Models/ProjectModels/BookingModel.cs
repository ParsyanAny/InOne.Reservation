using System;
using System.Collections.Generic;

namespace InOne.Reservation.Models
{
    public class BookingModel
    {
        public class FurnitureInfo
        {
            public int FurnitureId { get; set; }
            public int FurnitureCount { get; set; }
        }
        public int RoomNumber { get; set; }
        public int UserId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public IEnumerable<int> UsersIds { get; set; }
        public IEnumerable<FurnitureInfo> Furnitures { get; set; }
    }
}
