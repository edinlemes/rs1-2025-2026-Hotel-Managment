using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Billing
{
    public class PaymentsEntity : BaseEntity
    {
        public DateTime Date { get; set; }
        public decimal Payment { get; set; }

        public PaymentTypesEntity? PaymentType { get; set; }
        public int PaymentStatusId { get; set; }
        public int PaymentTypeId { get; set; }
        public int BillId { get; set; }
        public PaymentStatusEntity? PaymentStatus { get; set; }
        public BillsEntity? Bill { get; set; }
    }

}
