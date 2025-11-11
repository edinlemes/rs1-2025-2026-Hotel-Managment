using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Hotel
{
    public class RateTypes
    {
        public required int RateTypeID { get; set; }
        public required string RateTypeName { get; set; }
        public required string Description { get; set; }
        public required int SortOrder { get; set; }
        public required bool Active { get; set; }

        //public List<Rates> Rates { get; set; } = new();
    }
}
