using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InOne.Reservation.Repository.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }
        public DateTime? Time1 { get; set; }
        public DateTime? Time2 { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }
        public Room Room { get; set; }

        public ICollection<BookingFurniture> BookingFurnitures { get; set; }
        public ICollection<UserBooking> UserBookings { get; set; }

        //public Booking()
        //{
        //    BookingFurnitures = new HashSet<BookingFurniture>();
        //}
    }
}
