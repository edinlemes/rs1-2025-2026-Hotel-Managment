using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Hotel
{
    public class Rooms
    {
        public required int RoomID { get; set; }
        public required int HotelID { get; set; }
        public required int Floor { get; set; }
        public required int RoomTypeID { get; set; }
        public required string RoomNumber { get; set; }
        public required string Description { get; set; }
        public required int RoomStatusID { get; set; }

        //public required Hotels Hotel { get; set; }
        //public required RoomTypes RoomType { get; set; }
        //public required RoomStatus RoomStatus { get; set; }

        //public List<RoomAmenities> RoomAmenities { get; set; } = new();
        //public List<Rates> Rates { get; set; } = new();
        //public List<RoomsBooked> RoomsBooked { get; set; } = new();
        //public List<StaffRooms> StaffRooms { get; set; } = new();
    }
}
