using Hotel.Domain.Common;
using Hotel.Domain.Entities.Bookings;
using Hotel.Domain.Entities.Staff;

namespace Hotel.Domain.Entities.Hotel
{
    public class RoomsEntity : BaseEntity
    {
        public int Floor { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public HotelsEntity? Hotel { get; set; }
        public int HotelId { get; set; }
        public RoomTypesEntity? RoomType { get; set; }
        public int RoomTypeId { get; set; }
        public RoomStatusEntity? RoomStatus { get; set; }
        public int RoomStatusId { get; set; }

        public List<RoomAmenitiesEntity?> RoomAmenities { get; set; } = new();
        public List<RatesEntity?> Rates { get; set; } = new();
        public List<RoomsBookedEntity?> RoomsBooked { get; set; } = new();
        public List<StaffRoomsEntity?> StaffRooms { get; set; } = new();
    }
}
