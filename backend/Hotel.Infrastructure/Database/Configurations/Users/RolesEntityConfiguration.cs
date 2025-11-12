using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Users
{
    public class RolesEntityConfiguration : IEntityTypeConfiguration<RolesEntity>
    {
        public void Configure(EntityTypeBuilder<RolesEntity> builder)
        {
            builder.ToTable("Roles");

            builder.Property(x => x.RoleName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Active).IsRequired();
        }
    }
}
