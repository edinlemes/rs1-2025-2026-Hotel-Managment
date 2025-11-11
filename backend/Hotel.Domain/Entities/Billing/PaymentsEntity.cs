using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Billing
{
    public class Payments
    {
        public required int PaymentID { get; set; }
        public required DateTime Date { get; set; }
        public required decimal Payment { get; set; }
        public required int PaymentTypeID { get; set; }
        public required int PaymentStatusID { get; set; }
        public required int BillID { get; set; }

        //public required PaymentTypes PaymentType { get; set; }
        //public required PaymentStatus PaymentStatus { get; set; }
        //public required Bills Bill { get; set; }
    }

}
