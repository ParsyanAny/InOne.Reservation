using System.Collections.Generic;
using System.Linq;

namespace InOne.Reservation.Models
{
    public class RoomFurCost
    {
        public decimal RoomCost { get; set; }
        public decimal FullFurCost => FurnituresCost.Sum();
        public decimal TotalCost => FullFurCost != 0 ? FullFurCost + RoomCost : RoomCost;
        public IEnumerable<decimal> FurnituresCost { get; set; }
    }
}
