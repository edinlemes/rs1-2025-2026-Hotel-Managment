using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Staff
{
    public class Positions
    {
        public required int PositionID { get; set; }
        public required string PositionName { get; set; }
        public required int SortOrder { get; set; }
        public required bool Active { get; set; }

        //public List<Staff> Staff { get; set; } = new();
    }
}
