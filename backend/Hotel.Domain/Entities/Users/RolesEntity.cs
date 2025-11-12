using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Users
{
    public class RolesEntity : BaseEntity
    {
        public required string RoleName { get; set; }
        public required string Description { get; set; }
        public required bool Active { get; set; }

        public List<UserRolesEntity?> UserRoles { get; set; } = new();
    }
}
