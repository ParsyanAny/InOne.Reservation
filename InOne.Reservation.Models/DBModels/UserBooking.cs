using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InOne.Reservation.Models
{
    public class UserBooking
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Booking")]
        public int BookingId { get; set; }

        public User User { get; set; }
        public Booking Booking { get; set; }
    }
}