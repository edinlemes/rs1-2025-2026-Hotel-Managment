using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Bookings
{
    public class Channels : BaseEntity
    {
        public required string ChannelName { get; set; }
        public required string Description { get; set; }
        public required bool Active { get; set; }

        //public List<Bookings> Bookings { get; set; } = new();
    }

}
