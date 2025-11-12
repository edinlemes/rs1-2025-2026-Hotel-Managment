using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Staff
{
    public class StaffShiftAssignmentsEntity : BaseEntity
    {
        public DateTime AssignedDate { get; set; }

        public StaffEntity? Staff { get; set; }
        public int StaffId { get; set; }
        public StaffShiftEntity? Shift { get; set; }
        public int ShiftId { get; set; }
    }
}
