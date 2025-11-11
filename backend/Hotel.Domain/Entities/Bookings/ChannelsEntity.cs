using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Bookings
{
    public class Channels
    {
        public required int ChannelID { get; set; }
        public required string ChannelName { get; set; }
        public required string Description { get; set; }
        public required bool Active { get; set; }

        //public List<Bookings> Bookings { get; set; } = new();
    }

}
