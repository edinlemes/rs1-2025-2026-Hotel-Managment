using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Staff
{
    public class PositionsConfiguration : IEntityTypeConfiguration<PositionsEntity>
    {
        public void Configure(EntityTypeBuilder<PositionsEntity> builder)
        {
            builder.ToTable("Positions");

            builder.Property(x => x.PositionName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.SortOrder).IsRequired();
            builder.Property(x => x.Active).IsRequired();
        }
    }
}
