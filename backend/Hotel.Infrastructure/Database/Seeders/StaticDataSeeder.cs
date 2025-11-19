using Hotel.Domain.Entities.Users;

namespace Hotel.Infrastructure.Database.Seeders;

public partial class StaticDataSeeder
{
    private static DateTime DateTime { get; set; } = new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local);

    public static void Seed(ModelBuilder modelBuilder)
    {
        // Static data is added in the migration
        // if it does not exist in the DB at the time of creating the migration
        // example of static data: roles
        SeedProductCategories(modelBuilder);
    }

    private static void SeedProductCategories(ModelBuilder modelBuilder)
    {
        // todo: user roles

        modelBuilder.Entity<RolesEntity>().HasData(new List<RolesEntity>
        {
            new RolesEntity{
                Id = 1,
                RoleName = "Administrator",
                Description = "Administrator role with full permissions",
                Active = true,
                CreatedAtUtc = DateTime.UtcNow,
                ModifiedAtUtc = null,
        },
            new RolesEntity{
                Id = 2,
                RoleName = "User",
                Description = "Standard user role with limited permissions",
                Active = true,
                CreatedAtUtc = DateTime.UtcNow,
                ModifiedAtUtc = null,
            },
        });
    }
}