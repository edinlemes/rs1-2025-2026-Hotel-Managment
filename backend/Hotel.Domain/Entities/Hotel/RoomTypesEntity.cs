using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Hotel
{
    public class RoomTypesEntity : BaseEntity
    {
        public required string RoomTypeName { get; set; }
        public required string Description { get; set; }
        public required int SortOrder { get; set; }
        public required bool Active { get; set; }

        //public List<Rooms> Rooms { get; set; } = new();
    }
}
