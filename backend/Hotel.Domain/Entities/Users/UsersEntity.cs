using Hotel.Domain.Common;
using Hotel.Domain.Entities.Staff;

namespace Hotel.Domain.Entities.Users
{
    public class UsersEntity : BaseEntity
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public required bool Active { get; set; }
        public required DateTime CreatedAt { get; set; }

        public List<PersonsEntity?> Persons { get; set; } = new();
        public List<StaffEntity?> Staff { get; set; } = new();
        public List<UserRolesEntity?> UserRoles { get; set; } = new();
    }
}
