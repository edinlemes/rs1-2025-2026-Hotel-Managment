using Hotel.Domain.Common;
using Hotel.Domain.Entities.Hotel;
using Hotel.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Bookings
{
    public class Bookings : BaseEntity
    {
        public required int HotelID { get; set; }
        public required int PersonID { get; set; }
        public required DateTime DateFrom { get; set; }
        public required DateTime DateTo { get; set; }
        public required int RoomCount { get; set; }
        public required int BookingStatusID { get; set; }
        public required int DiscountID { get; set; }
        public required int ChannelID { get; set; }

        public required Hotels Hotel { get; set; }
        public required Persons Person { get; set; }
        public required BookingStatus BookingStatus { get; set; }
        public required Discounts Discount { get; set; }
        public required Channels Channel { get; set; }

        //public List<RoomsBooked> RoomsBooked { get; set; } = new();
        //public List<Bills> Bills { get; set; } = new();
        //public List<GuestServices> GuestServices { get; set; } = new();
    }
}
