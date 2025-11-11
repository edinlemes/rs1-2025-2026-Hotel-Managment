using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Hotel
{
    public class Hotels : BaseEntity
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

        //public List<Rooms> Rooms { get; set; } = new();
        //public List<Bookings> Bookings { get; set; } = new();
        //public List<HotelServices> HotelServices { get; set; } = new();
    }

}
