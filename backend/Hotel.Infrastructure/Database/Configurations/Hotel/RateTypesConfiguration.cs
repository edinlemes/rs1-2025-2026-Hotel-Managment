using Hotel.Domain.Common;
using Hotel.Domain.Entities.Hotel;

namespace Hotel.Infrastructure.Database.Conf.Hotel
{
    public class RateTypesConfiguration : IEntityTypeConfiguration<RateTypesEntity>
    {
        public void Configure(EntityTypeBuilder<RateTypesEntity> builder)
        {
            builder.ToTable("RateTypes");

            builder.Property(x => x.RateTypeName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
            builder.Property(x => x.SortOrder).IsRequired();
            builder.Property(x => x.Active).IsRequired();
        }
    }
}
