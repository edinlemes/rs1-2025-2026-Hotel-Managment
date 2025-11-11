using Hotel.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Staff
{
    public class StaffShiftEntity : BaseEntity
    {
        public required DateTime DateOfWork { get; set; }
        public required string ShiftType { get; set; }
        public required string Notes { get; set; }

        //public List<StaffShiftAssignments> Assignments { get; set; } = new();
    }
}
