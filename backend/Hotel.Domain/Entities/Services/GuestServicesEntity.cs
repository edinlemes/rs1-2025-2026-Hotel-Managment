using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Services
{
    public class GuestServices
    {
        public required int GuestServiceID { get; set; }
        public required int BookingID { get; set; }
        public required int HotelServiceID { get; set; }
        public required DateTime DateUsed { get; set; }
        public required int Quantity { get; set; }
        public required decimal TotalPrice { get; set; }

        //public required Bookings Booking { get; set; }
        public required HotelServices HotelService { get; set; }
    }
}
