namespace Hotel.Domain.Entities.Staff
{
    public class StaffRoomsConfiguration : IEntityTypeConfiguration<StaffRoomsEntity>
    {
        public void Configure(EntityTypeBuilder<StaffRoomsEntity> builder)
        {
            builder.ToTable("StaffRooms");

            builder.Property(x => x.RoomId).IsRequired();
            builder.Property(x => x.StaffId).IsRequired();

            builder
                .HasOne(x => x.Room)
                .WithMany(x => x.StaffRooms)
                .HasForeignKey(x => x.RoomId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Staff)
                .WithMany(x => x.StaffRooms)
                .HasForeignKey(x => x.StaffId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
