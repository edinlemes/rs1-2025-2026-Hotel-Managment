using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Staff
{
    public class StaffShiftEntity : BaseEntity
    {
        public required DateTime DateOfWork { get; set; }
        public required string ShiftType { get; set; }
        public required string Notes { get; set; }

        public List<StaffShiftAssignmentsEntity?> Assignments { get; set; } = new();
    }
}
