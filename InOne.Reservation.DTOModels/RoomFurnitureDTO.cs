using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InOne.Reservation.DTOModels
{
    public class RoomFurnitureDTO
    {
        [Key, Column(Order = 1), ForeignKey("Furniture")]
        public int FurnitureId { get; set; }
        [Key, Column(Order = 2), ForeignKey("Room")]
        public int RoomId { get; set; }

        public FurnitureDTO Furniture { get; set; }
        public RoomDTO Room { get; set; }
        public int Count { get; set; }
    }
}
