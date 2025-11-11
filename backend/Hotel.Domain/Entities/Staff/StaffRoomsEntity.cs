using Hotel.Domain.Common;
using Hotel.Domain.Entities.Hotel;

namespace Hotel.Domain.Entities.Staff
{
    public class StaffRooms : BaseEntity
    {
        public required int RoomID { get; set; }
        public required int StaffID { get; set; }

        public required Rooms Room { get; set; }
        public required Staff Staff { get; set; }
    }
}
