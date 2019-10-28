using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InOne.Reservation.DTOModels
{
    public class BookingFurnitureDTO
    {
        [Key, Column(Order = 1), ForeignKey("Booking")]
        public int BookingId { get; set; }
        [Key, Column(Order = 2), ForeignKey("Furniture")]
        public int FurnitureId { get; set; }

        public BookingDTO Booking { get; set; }
        public FurnitureDTO Furniture { get; set; }
        public int? Count { get; set; }
    }
}
