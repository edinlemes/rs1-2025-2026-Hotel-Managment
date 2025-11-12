using Hotel.Domain.Entities.Billing;

namespace Hotel.Infrastructure.Database.Configurations.Billing
{
    public class PaymentsConfiguration : IEntityTypeConfiguration<PaymentsEntity>
    {
        public void Configure(EntityTypeBuilder<PaymentsEntity> builder)
        {
            builder.ToTable("Payments");

            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Payment).IsRequired().HasPrecision(18, 2);

            builder
                .HasOne(x => x.PaymentType)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.PaymentTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.PaymentStatus)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.PaymentStatusId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Bill)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.BillId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

}
