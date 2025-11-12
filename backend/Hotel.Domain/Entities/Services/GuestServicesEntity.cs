using Hotel.Domain.Common;
using Hotel.Domain.Entities.Bookings;

namespace Hotel.Domain.Entities.Services
{
    public class GuestServicesEntity : BaseEntity
    {
        public DateTime DateUsed { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public BookingsEntity? Booking { get; set; }
        public int BookingId { get; set; }
        public HotelServicesEntity? HotelService { get; set; }
        public int HotelServiceId { get; set; }
    }
}
