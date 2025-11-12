namespace Hotel.Domain.Entities.Hotel
{
    public class HotelsConfiguration : IEntityTypeConfiguration<HotelsEntity>
    {
        public void Configure(EntityTypeBuilder<HotelsEntity> builder)
        {
            builder.ToTable("Hotels");

            builder.Property(x => x.HotelCode).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(100);
            builder.Property(x => x.City).IsRequired().HasMaxLength(50);
            builder.Property(x => x.State).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ZipCode).IsRequired().HasMaxLength(20);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CompanyMailAddress).IsRequired().HasMaxLength(100);
            builder.Property(x => x.WebsiteAddress).IsRequired().HasMaxLength(100);
        }
    }

}
