using Hotel.Domain.Common;
using Hotel.Domain.Entities.Hotel;

namespace Hotel.Domain.Entities.Services
{
    public class HotelServicesConfiguration : IEntityTypeConfiguration<HotelServicesEntity>
    {
        public void Configure(EntityTypeBuilder<HotelServicesEntity> builder)
        {
            builder.ToTable("HotelServices");

            builder.Property(x => x.ServiceName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Price).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.Active).IsRequired();

            builder
                .HasOne(x => x.Hotel)
                .WithMany(x => x.HotelServices)
                .HasForeignKey(x => x.HotelId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
