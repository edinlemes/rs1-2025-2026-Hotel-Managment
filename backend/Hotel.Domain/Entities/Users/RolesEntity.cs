using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Users
{
    public class Roles
    {
        public required int RoleID { get; set; }
        public required string RoleName { get; set; }
        public required string Description { get; set; }
        public required bool Active { get; set; }

        //public List<UserRoles> UserRoles { get; set; } = new();
    }
}
