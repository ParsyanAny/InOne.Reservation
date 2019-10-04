using System;

namespace InOne.Reservation.Models
{
    public partial class Booking
    {
        public decimal FullPrice => Room.Price * (EndTime.Hours - StartTime.Hours);
    }
}
