
namespace Hotel.Domain.Entities.Billing
{
    public class PaymentStatusConfiguration : IEntityTypeConfiguration<PaymentStatusEntity>
    {
        public void Configure(EntityTypeBuilder<PaymentStatusEntity> builder)
        {
            builder.ToTable("PaymentStatus");

            builder.Property(x => x.Status).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
            builder.Property(x => x.SortOrder).IsRequired();
            builder.Property(x => x.Active).IsRequired();
        }
    }
}
