using Hotel.Domain.Entities.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Services
{
    public class HotelServices
    {
        public required int HotelServiceID { get; set; }
        public required int HotelID { get; set; }
        public required string ServiceName { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required bool Active { get; set; }

        public required Hotels Hotel { get; set; }
        //public List<GuestServices> GuestServices { get; set; } = new();
    }
}
