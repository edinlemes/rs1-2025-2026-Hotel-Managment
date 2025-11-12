using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Hotel
{
    public class RateTypesEntity : BaseEntity
    {
        public required string RateTypeName { get; set; }
        public required string Description { get; set; }
        public required int SortOrder { get; set; }
        public required bool Active { get; set; }

        public List<RatesEntity?> Rates { get; set; } = new();
    }
}
