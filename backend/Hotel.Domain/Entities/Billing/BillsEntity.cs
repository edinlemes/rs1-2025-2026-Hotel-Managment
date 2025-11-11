using Hotel.Domain.Common;
using Hotel.Domain.Entities.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Billing
{
    public class BillsEntity :BaseEntity
    {
        public int BookingID { get; set; }
        public DateTime BillDate { get; set; }
        public decimal Subtotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
            
        public BookingsEntity? Booking { get; set; }
        public int BookingId { get; set; }
        public List<PaymentsEntity>? Payments { get; set; } = new();
    }
}
