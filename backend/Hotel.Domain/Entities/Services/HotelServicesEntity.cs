using Hotel.Domain.Common;
using Hotel.Domain.Entities.Hotel;

namespace Hotel.Domain.Entities.Services
{
    public class HotelServicesEntity : BaseEntity
    {
        public required int HotelID { get; set; }
        public required string ServiceName { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required bool Active { get; set; }

        public required Hotels Hotel { get; set; }
        //public List<GuestServices> GuestServices { get; set; } = new();
    }
}
