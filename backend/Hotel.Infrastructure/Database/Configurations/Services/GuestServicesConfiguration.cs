using Hotel.Domain.Common;
using Hotel.Domain.Entities.Bookings;

namespace Hotel.Domain.Entities.Services
{
    public class GuestServicesConfiguration : IEntityTypeConfiguration<GuestServicesEntity>
    {
        public void Configure(EntityTypeBuilder<GuestServicesEntity> builder)
        {
            builder.ToTable("GuestServices");

            builder.Property(x => x.DateUsed).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.TotalPrice).IsRequired().HasPrecision(18, 2);


            builder
                .HasOne(x => x.HotelService)
                .WithMany(x => x.GuestServices)
                .HasForeignKey(x => x.HotelServiceId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
