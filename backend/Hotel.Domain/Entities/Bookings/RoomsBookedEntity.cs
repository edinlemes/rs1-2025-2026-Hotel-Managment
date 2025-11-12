using Hotel.Domain.Common;
using Hotel.Domain.Entities.Hotel;

namespace Hotel.Domain.Entities.Bookings
{
    public class RoomsBookedEntity : BaseEntity
    {
        public DateTime DateBooked { get; set; }
        public bool Active { get; set; }

        public BookingsEntity? Booking { get; set; }
        public int BookingId { get; set; }
        public RoomsEntity? Room { get; set; }
        public int RoomId { get; set; }
    }
}
