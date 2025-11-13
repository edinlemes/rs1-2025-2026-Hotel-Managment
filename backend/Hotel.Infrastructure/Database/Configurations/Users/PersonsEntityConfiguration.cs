using Hotel.Domain.Entities.Users;

namespace Configurations.Entities
{
    // ==================== PersonsConfiguration ====================
    public class PersonsEntityConfiguration : IEntityTypeConfiguration<PersonsEntity>
    {
        public void Configure(EntityTypeBuilder<PersonsEntity> builder)
        {
            builder.ToTable("Persons");

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(100);
            builder.Property(x => x.City).IsRequired().HasMaxLength(50);
            builder.Property(x => x.State).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ZipCode).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Country).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.MailAddress).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Gender).IsRequired().HasMaxLength(20);
            builder.Property(x => x.UserId).IsRequired();

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Persons)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}