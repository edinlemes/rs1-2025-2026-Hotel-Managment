using Hotel.Domain.Common;
using Hotel.Domain.Entities.Bookings;
using Hotel.Domain.Entities.Staff;

namespace Hotel.Domain.Entities.Hotel
{
    public class RoomsConfiguration : IEntityTypeConfiguration<RoomsEntity>
    {
        public void Configure(EntityTypeBuilder<RoomsEntity> builder)
        {
            builder.ToTable("Rooms");

            builder.Property(x => x.Floor).IsRequired();
            builder.Property(x => x.RoomNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);

            builder
                .HasOne(x => x.Hotel)
                .WithMany(x => x.Rooms)
                .HasForeignKey(x => x.HotelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.RoomType)
                .WithMany(x => x.Rooms)
                .HasForeignKey(x => x.RoomTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.RoomStatus)
                .WithMany(x => x.Rooms)
                .HasForeignKey(x => x.RoomStatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
