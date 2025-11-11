using Hotel.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Hotel
{
    public class RoomStatusEntity : BaseEntity
    {
        public required string RoomStatusName { get; set; }
        public required string Description { get; set; }
        public required int SortOrder { get; set; }
        public required bool Active { get; set; }

        //public List<Rooms> Rooms { get; set; } = new();
    }
}
