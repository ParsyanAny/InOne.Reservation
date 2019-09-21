using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InOne.Reservation.Repository.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public bool IsEmpty { get; set; }
        [Required]
        public double Price { get; set; }
        public Room ParentRoom { get; set; }
        [ForeignKey("ParentRoom")]
        public int? ParentRoomId { get; set; }
        public ICollection<RoomFurniture> RoomFurnitures { get; set; }
    }
}