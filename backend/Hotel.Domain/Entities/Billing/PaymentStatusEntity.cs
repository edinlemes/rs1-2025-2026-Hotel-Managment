using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Billing
{
    public class PaymentStatusEntity : BaseEntity
    {
        public required string Status { get; set; }
        public required string Description { get; set; }
        public required int SortOrder { get; set; }
        public required bool Active { get; set; }

        public List<PaymentsEntity>? Payments { get; set; } = new();
    }
}
