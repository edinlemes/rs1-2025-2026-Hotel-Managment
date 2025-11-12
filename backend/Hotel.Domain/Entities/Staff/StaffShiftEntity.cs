using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Staff
{
    public class StaffShiftEntity : BaseEntity
    {
        public DateTime DateOfWork { get; set; }
        public string ShiftType { get; set; }
        public string Notes { get; set; }

        public List<StaffShiftAssignmentsEntity?> Assignments { get; set; } = new();
    }
}
