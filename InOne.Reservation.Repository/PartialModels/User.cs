using System;

namespace InOne.Reservation.Repository.Models
{
    public partial class User
    {
        public string FullName => $"{Surname} {Name}";
        public int? Age => DateTime.Now.Year - BirthYear.Year;
        public bool IsAdult => Age > 18 ? true : false;
        public string Adult => IsAdult ? "Is Adult" : "Is Teenage";
    }
}
