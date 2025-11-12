using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Staff
{
    public class StaffShiftAssignmentsConfiguration : IEntityTypeConfiguration<StaffShiftAssignmentsEntity>
    {
        public void Configure(EntityTypeBuilder<StaffShiftAssignmentsEntity> builder)
        {
            builder.ToTable("StaffShiftAssignments");

            builder.Property(x => x.AssignedDate).IsRequired();

            builder
                .HasOne(x => x.Staff)
                .WithMany(x => x.ShiftAssignments)
                .HasForeignKey(x => x.StaffId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Shift)
                .WithMany(x => x.Assignments)
                .HasForeignKey(x => x.ShiftId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
