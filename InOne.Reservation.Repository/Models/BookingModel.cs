using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InOne.Reservation.Repository.Models
{
    class BookingModel
    {
        public class FurnitureInfo
        {
            public int FurnitureId { get; set; }
            public int FurnitureCount { get; set; }
            public int FurnitureCost { get; set; }
        }
        public int RoomNumber { get; set; }
        public int UserId { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<FurnitureInfo> Furnitures { get; set; }
    }
}
