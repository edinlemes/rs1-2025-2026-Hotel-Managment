using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Hotel
{
    public class RoomAmenities
    {
        public required int RoomAmenityID { get; set; }
        public required int RoomID { get; set; }
        public required int AmenityID { get; set; }
        public required bool Active { get; set; }

        //public required Rooms Room { get; set; }
        //public required Amenities Amenity { get; set; }
    }
}
