using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InOne.Reservation.Repository.Models
{
    public class BookingFurniture
    {
        [Key, Column(Order = 1), ForeignKey("Booking")]
        public int BookingId { get; set; }
        [Key, Column(Order = 2), ForeignKey("Furniture")]
        public int FurnitureId { get; set; }

        public Booking Booking { get; set; }
        public Furniture Furniture { get; set; }
        public int? Count { get; set; }
    }
}