using Hotel.Domain.Entities.Bookings;

namespace Hotel.Infrastructure.Database.Conf.Bookings;

public class BookingsConfiguration : IEntityTypeConfiguration<BookingsEntity>
{
    public void Configure(EntityTypeBuilder<BookingsEntity> builder)
    {
        builder.ToTable("Bookings");

        builder.Property(x => x.DateFrom).IsRequired();
        builder.Property(x => x.DateTo).IsRequired();
        builder.Property(x => x.RoomCount).IsRequired();

        builder
            .HasOne(x => x.Hotel)
            .WithMany(x => x.Bookings)
            .HasForeignKey(x => x.HotelId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(x => x.Person)
            .WithMany(x => x.Bookings)
            .HasForeignKey(x => x.PersonId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(x => x.BookingStatus)
            .WithMany(x => x.Bookings)
            .HasForeignKey(x => x.BookingStatusId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(x => x.Discount)
            .WithMany(x => x.Bookings)
            .HasForeignKey(x => x.DiscountId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(x => x.Channel)
            .WithMany(x => x.Bookings)
            .HasForeignKey(x => x.ChannelId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
