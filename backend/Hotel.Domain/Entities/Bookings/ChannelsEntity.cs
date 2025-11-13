using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Bookings
{
    public class ChannelsEntity : BaseEntity
    {
        public string ChannelName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public List<BookingsEntity?> Bookings { get; set; } = new();
    }

}
