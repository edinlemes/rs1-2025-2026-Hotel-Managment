using Hotel.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Billing
{
    public class PaymentStatus : BaseEntity
    {
        public required string Status { get; set; }
        public required string Description { get; set; }
        public required int SortOrder { get; set; }
        public required bool Active { get; set; }

        //public List<Payments> Payments { get; set; } = new();
    }
}
