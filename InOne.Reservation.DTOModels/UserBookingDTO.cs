using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InOne.Reservation.DTOModels
{
    public class UserBookingDTO
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Booking")]
        public int BookingId { get; set; }

        public UserDTO UserDTO { get; set; }
        public BookingDTO BookingDTO { get; set; }
    }
}
