using Hotel.Domain.Entities.Bookings;

namespace Hotel.Infrastructure.Database.Conf.Bookings
{
    public class DiscountsConfiguration : IEntityTypeConfiguration<DiscountsEntity>
    {
        public void Configure(EntityTypeBuilder<DiscountsEntity> builder)
        {
            builder.ToTable("Discounts");

            builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DiscountType).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.Value).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.Active).IsRequired();
        }
    }
}
