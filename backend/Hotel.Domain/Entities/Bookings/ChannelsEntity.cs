using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Bookings
{
    public class ChannelsEntity : BaseEntity
    {
        public required string ChannelName { get; set; }
        public required string Description { get; set; }
        public required bool Active { get; set; }

        public List<BookingsEntity?> Bookings { get; set; } = new();
    }

}
