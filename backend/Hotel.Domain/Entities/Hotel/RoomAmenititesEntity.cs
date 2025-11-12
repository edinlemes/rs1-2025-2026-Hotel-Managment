using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Hotel
{
    public class RoomAmenitiesEntity : BaseEntity
    {
        public required int RoomID { get; set; }
        public required int AmenityID { get; set; }
        public required bool Active { get; set; }

        public required RoomsEntity? Room { get; set; }
        public int RoomId { get; set; }
        public required AmenitiesEntity? Amenity { get; set; }
        public int AmenityId { get; set; }
    }
}
