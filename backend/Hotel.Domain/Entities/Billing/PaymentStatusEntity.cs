using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Billing
{
    public class PaymentStatusEntity : BaseEntity
    {
        public string Status { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool Active { get; set; }

        public List<PaymentsEntity>? Payments { get; set; } = new();
    }
}
