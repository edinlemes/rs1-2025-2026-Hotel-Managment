using Hotel.Domain.Common;
using Hotel.Domain.Entities.Bookings;
using Hotel.Domain.Entities.Services;

namespace Hotel.Domain.Entities.Hotel
{
    public class HotelsEntity : BaseEntity
    {
        public required string HotelCode { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }
        public required string PhoneNumber { get; set; }
        public required string CompanyMailAddress { get; set; }
        public required string WebsiteAddress { get; set; }

        public List<RoomsEntity?> Rooms { get; set; } = new();
        public List<BookingsEntity?> Bookings { get; set; } = new();
        public List<HotelServicesEntity?> HotelServices { get; set; } = new();
    }

}
