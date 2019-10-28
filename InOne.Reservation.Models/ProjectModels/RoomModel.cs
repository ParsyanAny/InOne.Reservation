using System.Collections.Generic;

namespace InOne.Reservation.Models
{
    public class RoomModel
    {
        
        public int Id { get; set; }
        public int Number { get; set; }
        public double Price { get; set; }
        public bool IsEmpty { get; set; }
        public IEnumerable<FurnitureInfo> Furnitures { get; set; }
        public int? ParentRoomId { get; set; }
    }
}
