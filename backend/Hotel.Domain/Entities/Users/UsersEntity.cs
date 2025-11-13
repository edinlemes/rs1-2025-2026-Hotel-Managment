using Hotel.Domain.Common;
using Hotel.Domain.Entities.Staff;

namespace Hotel.Domain.Entities.Users
{
    public class UsersEntity : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<PersonsEntity?> Persons { get; set; } = new();
        public List<StaffEntity?> Staff { get; set; } = new();
        public List<UserRolesEntity?> UserRoles { get; set; } = new();
    }
}
