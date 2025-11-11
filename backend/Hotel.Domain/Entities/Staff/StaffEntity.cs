using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Staff
{
    public class Staff
    {
        public required int StaffID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required int PositionID { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }
        public required string PhoneNumber { get; set; }
        public required string MailAddress { get; set; }
        public required int UserID { get; set; }
        public required DateTime StartDate { get; set; }

        //public required Positions Position { get; set; }
        //public required Users User { get; set; }

        //public List<StaffRooms> StaffRooms { get; set; } = new();
        //public List<StaffShiftAssignments> ShiftAssignments { get; set; } = new();
    }
}
