using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Users
{
    public class RolesEntity : BaseEntity
    {
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public List<UserRolesEntity?> UserRoles { get; set; } = new();
    }
}
