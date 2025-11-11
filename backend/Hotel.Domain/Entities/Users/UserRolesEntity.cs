using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Users
{
    public class UserRoles : BaseEntity
    {
        public required int UserID { get; set; }
        public required int RoleID { get; set; }
        public required DateTime AssignedDate { get; set; }
        public required bool Active { get; set; }

        //public required Users User { get; set; }
        //public required Roles Role { get; set; }
    }
}
