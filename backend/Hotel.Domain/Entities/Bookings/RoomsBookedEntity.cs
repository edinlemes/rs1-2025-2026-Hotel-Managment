using Hotel.Domain.Entities.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Bookings
{
    public class RoomsBooked
    {
        public required int RoomBookedID { get; set; }
        public required int BookingID { get; set; }
        public required int RoomID { get; set; }
        public required DateTime DateBooked { get; set; }
        public required bool Active { get; set; }

        public required Bookings Booking { get; set; }
        public required Rooms Room { get; set; }
    }
}
