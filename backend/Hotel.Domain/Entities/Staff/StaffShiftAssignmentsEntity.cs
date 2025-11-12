using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Staff
{
    public class StaffShiftAssignmentsEntity : BaseEntity
    {
        public required DateTime AssignedDate { get; set; }

        public required StaffEntity? Staff { get; set; }
        public int StaffId { get; set; }
        public required StaffShiftEntity? Shift { get; set; }
        public int ShiftId { get; set; }
    }
}
