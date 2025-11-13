using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Billing
{
    public class PaymentTypesConfiguration : IEntityTypeConfiguration<PaymentTypesEntity>
    {
        public void Configure(EntityTypeBuilder<PaymentTypesEntity> builder)
        {
            builder.ToTable("PaymentTypes");

            builder.Property(x => x.PaymentTypeName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.SortOrder).IsRequired();
            builder.Property(x => x.Active).IsRequired();
        }
    }
}
