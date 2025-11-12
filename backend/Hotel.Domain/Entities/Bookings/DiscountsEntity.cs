using Hotel.Domain.Common;


namespace Hotel.Domain.Entities.Bookings
{
    public class DiscountsEntity : BaseEntity
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal DiscountType { get; set; }
        public decimal Value { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }

        public List<BookingsEntity>? Bookings { get; set; } = new();
    }
}
