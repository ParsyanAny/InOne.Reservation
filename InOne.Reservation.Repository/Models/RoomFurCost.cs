using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InOne.Reservation.Repository.Models.RoomFurCost;

namespace InOne.Reservation.Repository.Models
{
    public class RoomFurCost
    {
        public double RoomCost { get; set; }
        public double FullFurCost => FurnituresCost.Sum();
        public double TotalCost => FullFurCost!=0 ? FullFurCost + RoomCost : RoomCost;
        public IEnumerable<double> FurnituresCost { get; set; }
    }
}
