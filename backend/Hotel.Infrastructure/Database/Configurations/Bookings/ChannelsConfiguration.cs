using Hotel.Domain.Common;
using Hotel.Domain.Entities.Bookings;

namespace Hotel.Infrastructure.Database.Conf.Bookings
{
    public class ChannelsConfiguration : IEntityTypeConfiguration<ChannelsEntity>
    {
        public void Configure(EntityTypeBuilder<ChannelsEntity> builder)
        {
            builder.ToTable("Channels");

            builder.Property(x => x.ChannelName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Active).IsRequired();
        }
    }
}
