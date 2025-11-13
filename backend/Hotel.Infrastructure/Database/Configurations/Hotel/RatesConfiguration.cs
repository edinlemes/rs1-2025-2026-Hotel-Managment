using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Hotel
{
    public class RatesConfiguration : IEntityTypeConfiguration<RatesEntity>
    {
        public void Configure(EntityTypeBuilder<RatesEntity> builder)
        {
            builder.ToTable("Rates");

            builder.Property(x => x.Rate).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.FromDate).IsRequired();
            builder.Property(x => x.ToDate).IsRequired();

            builder
                .HasOne(x => x.Room)
                .WithMany(x => x.Rates)
                .HasForeignKey(x => x.RoomId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.RateType)
                .WithMany(x => x.Rates)
                .HasForeignKey(x => x.RateTypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
