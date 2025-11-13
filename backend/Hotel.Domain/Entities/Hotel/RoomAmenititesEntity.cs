using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Hotel
{
    public class RoomAmenitiesEntity : BaseEntity
    {
        public bool Active { get; set; }

        public RoomsEntity? Room { get; set; }
        public int RoomId { get; set; }
        public AmenitiesEntity? Amenity { get; set; }
        public int AmenityId { get; set; }
    }
}
