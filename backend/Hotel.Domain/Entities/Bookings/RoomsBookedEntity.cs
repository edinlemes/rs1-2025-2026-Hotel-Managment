using Hotel.Domain.Common;
using Hotel.Domain.Entities.Hotel;

namespace Hotel.Domain.Entities.Bookings
{
    public class RoomsBookedEntity : BaseEntity
    {
        public required int BookingID { get; set; }
        public required int RoomID { get; set; }
        public required DateTime DateBooked { get; set; }
        public required bool Active { get; set; }

        public required BookingsEntity? Booking { get; set; }
        public int BookingId { get; set; }
        public required RoomsEntity? Room { get; set; }
        public int RoomId { get; set; }
    }
}
