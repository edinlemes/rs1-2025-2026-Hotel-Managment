using Hotel.Domain.Entities.Bookings;

namespace Hotel.Infrastructure.Database.Conf.Bookings
{
    public class RoomsBookedConfiguration : IEntityTypeConfiguration<RoomsBookedEntity>
    {
        public void Configure(EntityTypeBuilder<RoomsBookedEntity> builder)
        {
            builder.ToTable("RoomsBooked");

            builder.Property(x => x.BookingId).IsRequired();
            builder.Property(x => x.RoomId).IsRequired();
            builder.Property(x => x.DateBooked).IsRequired();
            builder.Property(x => x.Active).IsRequired();


            builder
                .HasOne(x => x.Room)
                .WithMany(x => x.RoomsBooked)
                .HasForeignKey(x => x.RoomId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
