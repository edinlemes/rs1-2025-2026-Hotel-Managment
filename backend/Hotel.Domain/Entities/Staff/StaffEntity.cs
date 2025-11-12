using Hotel.Domain.Common;
using Hotel.Domain.Entities.Users;

namespace Hotel.Domain.Entities.Staff
{
    public class StaffEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public DateTime StartDate { get; set; }

        public PositionsEntity? Position { get; set; }
        public int PositionId { get; set; } 
        public UsersEntity? User { get; set; }
        public int UserId { get; set; }
        public List<StaffRoomsEntity?> StaffRooms { get; set; } = new();
        public List<StaffShiftAssignmentsEntity?> ShiftAssignments { get; set; } = new();
    }
}
