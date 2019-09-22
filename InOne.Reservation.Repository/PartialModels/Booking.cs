using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InOne.Reservation.Repository.Models
{
   public partial class Booking
    {
        public double FullPrice => Room.Price * Convert.ToDouble(EndTime - StartTime);
    }
}
