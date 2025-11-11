using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Users
{
    public class Users
    {
        public required int UserID { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public required bool Active { get; set; }
        public required DateTime CreatedAt { get; set; }

        //public List<Persons> Persons { get; set; } = new();
        //public List<Staff> Staff { get; set; } = new();
        //public List<UserRoles> UserRoles { get; set; } = new();
    }
}
