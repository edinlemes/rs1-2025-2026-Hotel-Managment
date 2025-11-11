using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Users
{
    public class UsersEntity : BaseEntity
    {
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
