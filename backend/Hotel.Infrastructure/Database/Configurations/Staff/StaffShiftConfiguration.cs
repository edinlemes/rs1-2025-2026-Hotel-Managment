using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Staff
{
    public class StaffShiftConfiguration : IEntityTypeConfiguration<StaffShiftEntity>
    {
        public void Configure(EntityTypeBuilder<StaffShiftEntity> builder)
        {
            builder.ToTable("StaffShift");

            builder.Property(x => x.DateOfWork).IsRequired();
            builder.Property(x => x.ShiftType).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Notes).IsRequired().HasMaxLength(100);
        }
    }
}
