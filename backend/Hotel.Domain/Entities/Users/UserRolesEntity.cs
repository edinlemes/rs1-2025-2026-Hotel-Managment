using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Users
{
    public class UserRolesEntity : BaseEntity
    {
        public DateTime AssignedDate { get; set; }
        public bool Active { get; set; }

        public UsersEntity? User { get; set; }
        public int UserId { get; set; }
        public RolesEntity? Role { get; set; }
        public int RoleId { get; set; }
    }
}
