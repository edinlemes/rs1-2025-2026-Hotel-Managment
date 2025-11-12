using Hotel.Domain.Common;
using Hotel.Domain.Entities.Hotel;

namespace Hotel.Domain.Entities.Staff
{
    public class StaffRoomsEntity : BaseEntity
    {
        public RoomsEntity? Room { get; set; }
        public int RoomId { get; set; }
        public StaffEntity? Staff { get; set; }
        public int StaffId { get; set; }
    }
}
