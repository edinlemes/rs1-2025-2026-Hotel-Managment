using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Billing
{
    public class PaymentTypes
    {
        public required int PaymentTypeID { get; set; }
        public required string PaymentTypeName { get; set; }
        public required int SortOrder { get; set; }
        public required bool Active { get; set; }

        //public List<Payments> Payments { get; set; } = new();
    }
}
