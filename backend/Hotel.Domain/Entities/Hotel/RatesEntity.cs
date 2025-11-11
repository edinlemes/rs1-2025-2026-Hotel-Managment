using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Hotel
{
    public class Rates
    {
        public required int RateID { get; set; }
        public required int RoomID { get; set; }
        public required decimal Rate { get; set; }
        public required DateTime FromDate { get; set; }
        public required DateTime ToDate { get; set; }
        public required int RateTypeID { get; set; }

        //public required Rooms Room { get; set; }
        //public required RateTypes RateType { get; set; }
    }
}
