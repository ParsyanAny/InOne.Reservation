using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InOne.Reservation.DTOModels
{
    public class BookingDTO
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

        public UserDTO UserDTO { get; set; }
        public RoomDTO RoomDTO { get; set; }

        public ICollection<BookingFurnitureDTO> BookingFurnituresDTO { get; set; }
        public ICollection<UserBookingDTO> UserBookingsDTO { get; set; }
    }
}
