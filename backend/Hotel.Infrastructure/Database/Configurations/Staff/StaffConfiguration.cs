using Hotel.Domain.Common;
using Hotel.Domain.Entities.Users;

namespace Hotel.Domain.Entities.Staff
{
    public class StaffConfiguration : IEntityTypeConfiguration<StaffEntity>
    {
        public void Configure(EntityTypeBuilder<StaffEntity> builder)
        {
            builder.ToTable("Staff");

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(100);
            builder.Property(x => x.City).IsRequired().HasMaxLength(50);
            builder.Property(x => x.State).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ZipCode).IsRequired().HasMaxLength(20);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.MailAddress).IsRequired().HasMaxLength(100);
            builder.Property(x => x.StartDate).IsRequired();

            builder
                .HasOne(x => x.Position)
                .WithMany(x => x.Staff)
                .HasForeignKey(x => x.PositionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Staff)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
