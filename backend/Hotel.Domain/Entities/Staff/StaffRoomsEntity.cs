using Hotel.Domain.Entities.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Staff
{
    public class StaffRooms
    {
        public required int StaffRoomID { get; set; }
        public required int RoomID { get; set; }
        public required int StaffID { get; set; }

        public required Rooms Room { get; set; }
        public required Staff Staff { get; set; }
    }
}
