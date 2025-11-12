using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Hotel
{
    public class RoomAmenitiesConfiguration : IEntityTypeConfiguration<RoomAmenitiesEntity>
    {
        public void Configure(EntityTypeBuilder<RoomAmenitiesEntity> builder)
        {
            builder.ToTable("RoomAmenities");

            builder.Property(x => x.Active).IsRequired();

            builder
                .HasOne(x => x.Room)
                .WithMany(x => x.RoomAmenities)
                .HasForeignKey(x => x.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Amenity)
                .WithMany(x => x.RoomAmenities)
                .HasForeignKey(x => x.AmenityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
