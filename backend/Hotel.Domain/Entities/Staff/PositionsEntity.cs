using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Staff
{
    public class PositionsEntity : BaseEntity
    {
        public string PositionName { get; set; }
        public int SortOrder { get; set; }
        public bool Active { get; set; }

        public List<StaffEntity?> Staff { get; set; } = new();
    }
}
