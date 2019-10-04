using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InOne.Reservation.Models
{
    public class Furniture
    {
        [Key]
        public int FurnitureId { get; set; }
        [MaxLength(50)]
        [Required]
        public string TypeName { get; set; }
        public decimal Price { get; set; }
        public ICollection<BookingFurniture> BookingFurniture { get; set; }
        public ICollection<RoomFurniture> RoomFurniture { get; set; }
    }
}