using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Hotel
{
    public class RoomStatusEntity : BaseEntity
    {
        public string RoomStatusName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public bool Active { get; set; }

        public List<RoomsEntity?> Rooms { get; set; } = new();
    }
}
