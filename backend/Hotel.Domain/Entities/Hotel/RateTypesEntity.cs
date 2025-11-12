using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Hotel
{
    public class RateTypesEntity : BaseEntity
    {
        public string RateTypeName { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool Active { get; set; }

        public List<RatesEntity?> Rates { get; set; } = new();
    }
}
