using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Users
{
    public class PositionsEntity : BaseEntity
    {
        public required string PositionName { get; set; }
        public required int SortOrder { get; set; }
        public required bool Active { get; set; }

        //public List<Staff> Staff { get; set; } = new();
    }
}
