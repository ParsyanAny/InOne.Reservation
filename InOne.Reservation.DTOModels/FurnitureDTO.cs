using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InOne.Reservation.DTOModels
{
    public class FurnitureDTO
    {
        [Key]
        public int FurnitureId { get; set; }
        [MaxLength(50)]
        [Required]
        public string TypeName { get; set; }
        public decimal Price { get; set; }
        public ICollection<BookingFurnitureDTO> BookingFurniture { get; set; }
        public ICollection<RoomFurnitureDTO> RoomFurniture { get; set; }
    }
}
