using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Hotel
{
    public class RoomTypes
    {
        public required int RoomTypeID { get; set; }
        public required string RoomTypeName { get; set; }
        public required string Description { get; set; }
        public required int SortOrder { get; set; }
        public required bool Active { get; set; }

        //public List<Rooms> Rooms { get; set; } = new();
    }
}
