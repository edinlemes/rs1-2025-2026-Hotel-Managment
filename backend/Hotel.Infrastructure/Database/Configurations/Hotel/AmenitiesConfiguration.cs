
using Hotel.Domain.Entities.Hotel;

namespace Hotel.Infrastructure.Database.Conf.Hotel
{
    public class AmenitiesConfiguration : IEntityTypeConfiguration<AmenitiesEntity>
    {
        public void Configure(EntityTypeBuilder<AmenitiesEntity> builder)
        {
            builder.ToTable("Amenities");

            builder.Property(x => x.AmenityName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Active).IsRequired();
        }
    }
}
