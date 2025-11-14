namespace Hotel.Domain.Entities.Users
{
    public class UserRolesEntityConfiguration : IEntityTypeConfiguration<UserRolesEntity>
    {
        public void Configure(EntityTypeBuilder<UserRolesEntity> builder)
        {
            builder.ToTable("UserRoles");

            builder.Property(x => x.AssignedDate).IsRequired();
            builder.Property(x => x.Active).IsRequired();

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Role)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
