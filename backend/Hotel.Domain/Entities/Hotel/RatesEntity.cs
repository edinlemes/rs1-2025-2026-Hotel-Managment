using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Hotel
{
    public class RatesEntity : BaseEntity
    {
        public int RoomID { get; set; }
        public decimal Rate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int RateTypeID { get; set; }

        public RoomsEntity? Room { get; set; }
        public RateTypesEntity? RateType { get; set; }
    }
}
