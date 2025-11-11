using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Bookings
{
    public class Discounts
    {
        public required int DiscountID { get; set; }
        public required string Code { get; set; }
        public required string Description { get; set; }
        public required decimal DiscountType { get; set; }
        public required decimal Value { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required bool Active { get; set; }

        //public List<Bookings> Bookings { get; set; } = new();
    }
}
