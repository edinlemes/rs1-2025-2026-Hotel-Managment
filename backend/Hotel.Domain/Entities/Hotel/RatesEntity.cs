using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Hotel
{
    public class RatesEntity : BaseEntity
    {
        public decimal Rate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public RoomsEntity? Room { get; set; }
        public int RoomId { get; set; }
        public RateTypesEntity? RateType { get; set; }
        public int RateTypeId { get; set; }
    }
}
