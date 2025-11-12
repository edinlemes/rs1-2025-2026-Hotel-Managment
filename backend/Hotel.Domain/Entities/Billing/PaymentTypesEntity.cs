using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Billing
{
    public class PaymentTypesEntity : BaseEntity
    {
        public required string PaymentTypeName { get; set; }
        public required int SortOrder { get; set; }
        public required bool Active { get; set; }

        public List<PaymentsEntity>? Payments { get; set; } = new();
    }
}
