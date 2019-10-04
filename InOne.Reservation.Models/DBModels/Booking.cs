using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InOne.Reservation.Models
{
    public partial class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }
        public TimeSpan? Time1 { get; set; }
        public TimeSpan? Time2 { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }
        public Room Room { get; set; }

        public ICollection<BookingFurniture> BookingFurnitures { get; set; }
        public ICollection<UserBooking> UserBookings { get; set; }
    }
}
