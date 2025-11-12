
using Hotel.Domain.Entities.Billing;

namespace Hotel.Infrastructure.Database.Configurations.Billing;

public class BillsConfiguration : IEntityTypeConfiguration<BillsEntity>
{
    public void Configure(EntityTypeBuilder<BillsEntity> builder)
    {
        builder.ToTable("Bills");

        builder.Property(x => x.BillDate).IsRequired();
        builder.Property(x => x.Subtotal).IsRequired().HasPrecision(18, 2);
        builder.Property(x => x.DiscountAmount).IsRequired().HasPrecision(18, 2);
        builder.Property(x => x.TotalAmount).IsRequired().HasPrecision(18, 2);

    
    }
}
