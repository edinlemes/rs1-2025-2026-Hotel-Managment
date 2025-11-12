using Hotel.Domain.Common;
using Hotel.Domain.Entities.Bookings;

namespace Hotel.Domain.Entities.Services
{
    public class GuestServicesEntity : BaseEntity
    {
        public required DateTime DateUsed { get; set; }
        public required int Quantity { get; set; }
        public required decimal TotalPrice { get; set; }

        public required BookingsEntity? Booking { get; set; }
        public int BookingId { get; set; }
        public required HotelServicesEntity? HotelService { get; set; }
        public int HotelServiceId { get; set; }
    }
}
