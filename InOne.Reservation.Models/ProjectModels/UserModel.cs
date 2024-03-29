﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InOne.Reservation.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Balance { get; set; }
        public DateTime BirthYear { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public IEnumerable<int> FriendsIds { get; set; }
    }
}
