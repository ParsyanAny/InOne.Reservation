using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InOne.Reservation.Repository.Models
{
    public class RoomFurniture
    {
        [Key, Column(Order = 1),ForeignKey("Furniture")]
        public int FurnitureId { get; set; }
        [Key, Column(Order = 2),ForeignKey("Room")]
        public int RoomId { get; set; }

        public Furniture Furniture { get; set; }
        public Room Room { get; set; }
        public int Count { get; set; }
    }
}
