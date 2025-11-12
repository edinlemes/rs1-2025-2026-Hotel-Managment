using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Hotel
{
    public class RoomTypesConfiguration : IEntityTypeConfiguration<RoomTypesEntity>
    {
        public void Configure(EntityTypeBuilder<RoomTypesEntity> builder)
        {
            builder.ToTable("RoomTypes");

            builder.Property(x => x.RoomTypeName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
            builder.Property(x => x.SortOrder).IsRequired();
            builder.Property(x => x.Active).IsRequired();
        }
    }
}
