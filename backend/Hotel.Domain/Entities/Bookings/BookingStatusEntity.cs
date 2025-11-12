using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Bookings
{
    public class BookingStatusEntity : BaseEntity
    {
        public string Status { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool Active { get; set; }

        public List<BookingsEntity?> Bookings { get; set; } = new();
    }
}
