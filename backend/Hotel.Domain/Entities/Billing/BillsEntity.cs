using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Billing
{
    public class Bills
    {
        public required int BillID { get; set; }
        public required int BookingID { get; set; }
        public required DateTime BillDate { get; set; }
        public required decimal Subtotal { get; set; }
        public required decimal DiscountAmount { get; set; }
        public required decimal TotalAmount { get; set; }

        //public required Bookings Booking { get; set; }
        //public List<Payments> Payments { get; set; } = new();
    }
}
