using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Staff
{
    public class StaffShiftAssignments : BaseEntity
    {
        public required int StaffID { get; set; }
        public required int ShiftID { get; set; }
        public required DateTime AssignedDate { get; set; }

        //public required Staff Staff { get; set; }
        //public required StaffShift Shift { get; set; }
    }
}
