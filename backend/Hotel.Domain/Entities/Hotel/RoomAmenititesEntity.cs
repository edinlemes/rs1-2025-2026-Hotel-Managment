using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Hotel
{
    public class RoomAmenitiesEntity : BaseEntity
    {
        public required int RoomID { get; set; }
        public required int AmenityID { get; set; }
        public required bool Active { get; set; }

        //public required Rooms Room { get; set; }
        //public required Amenities Amenity { get; set; }
    }
}
