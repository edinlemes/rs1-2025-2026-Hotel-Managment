using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Hotel
{
    public class AmenitiesEntity : BaseEntity
    {
        public required string AmenityName { get; set; }
        public required string Description { get; set; }
        public required bool Active { get; set; }

        public List<RoomAmenitiesEntity?> RoomAmenities { get; set; } = new();
    }
}
