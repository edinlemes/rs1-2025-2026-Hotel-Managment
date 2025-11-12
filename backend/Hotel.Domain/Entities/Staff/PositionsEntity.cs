using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Staff
{
    public class PositionsEntity : BaseEntity
    {
        public required string PositionName { get; set; }
        public required int SortOrder { get; set; }
        public required bool Active { get; set; }

        public List<StaffEntity?> Staff { get; set; } = new();
    }
}
