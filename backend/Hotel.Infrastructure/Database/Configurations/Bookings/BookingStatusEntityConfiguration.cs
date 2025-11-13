using Hotel.Domain.Entities.Bookings;

namespace Hotel.Infrastructure.Database.Conf.Bookings
{
    public class BookingStatusEntityConfiguration : IEntityTypeConfiguration<BookingStatusEntity>
    {
        public void Configure(EntityTypeBuilder<BookingStatusEntity> builder)
        {
            builder.ToTable("BookingStatus");

            builder.Property(x => x.Status).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
            builder.Property(x => x.SortOrder).IsRequired();
            builder.Property(x => x.Active).IsRequired();
        }
    }
}
