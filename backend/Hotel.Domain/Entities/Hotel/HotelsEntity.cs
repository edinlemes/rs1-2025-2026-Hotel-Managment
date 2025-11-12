using Hotel.Domain.Common;
using Hotel.Domain.Entities.Bookings;
using Hotel.Domain.Entities.Services;

namespace Hotel.Domain.Entities.Hotel
{
    public class HotelsEntity : BaseEntity
    {
        public string HotelCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyMailAddress { get; set; }
        public string WebsiteAddress { get; set; }

        public List<RoomsEntity?> Rooms { get; set; } = new();
        public List<BookingsEntity?> Bookings { get; set; } = new();
        public List<HotelServicesEntity?> HotelServices { get; set; } = new();
    }

}
