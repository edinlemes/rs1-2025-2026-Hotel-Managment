using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Staff
{
    public class StaffShiftAssignments
    {
        public required int AssignmentID { get; set; }
        public required int StaffID { get; set; }
        public required int ShiftID { get; set; }
        public required DateTime AssignedDate { get; set; }

        //public required Staff Staff { get; set; }
        //public required StaffShift Shift { get; set; }
    }
}
