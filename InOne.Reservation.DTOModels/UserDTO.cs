using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InOne.Reservation.DTOModels
{
    public class UserDTO
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string Name { get; set; }
        [MaxLength(70), Required]
        public string Surname { get; set; }
        public DateTime BirthYear { get; set; }
        public decimal Balance { get; set; }
        [MaxLength(200), Required]
        public string UserName { get; set; }
        [MaxLength(200), Required]
        public string Password { get; set; }
        public ICollection<UserBookingDTO> UserBookingsDTO { get; set; }
    }
}
