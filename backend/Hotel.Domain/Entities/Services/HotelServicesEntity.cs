using Hotel.Domain.Common;
using Hotel.Domain.Entities.Hotel;

namespace Hotel.Domain.Entities.Services
{
    public class HotelServicesEntity : BaseEntity
    {
        public string ServiceName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool Active { get; set; }

        public HotelsEntity? Hotel { get; set; }
        public int HotelId { get; set; }
        public List<GuestServicesEntity?> GuestServices { get; set; } = new();
    }
}
