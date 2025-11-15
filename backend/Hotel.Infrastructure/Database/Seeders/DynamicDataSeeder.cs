using Hotel.Domain.Entities.Users;

namespace Hotel.Infrastructure.Database.Seeders;

/// <summary>
/// Dynamic seeder koji se pokreće u runtime-u,
/// obično pri startu aplikacije (npr. u Program.cs).
/// Koristi se za unos demo/test podataka koji nisu dio migracije.
/// </summary>
public static class DynamicDataSeeder
{
    public static async Task SeedAsync(DatabaseContext context)
    {
        // Osiguraj da baza postoji (bez migracija)
        await context.Database.EnsureCreatedAsync();

        //await SeedProductCategoriesAsync(context);
        await SeedUsersAsync(context);
    }

    //    private static async Task SeedProductCategoriesAsync(DatabaseContext context)
    //    {
    //        if (!await context.ProductCategories.AnyAsync())
    //        {
    //            context.ProductCategories.AddRange(
    //                new ProductCategoryEntity
    //                {
    //                    Name = "Računari (demo)",
    //                    //IsEnabled = true,
    //                    CreatedAtUtc = DateTime.UtcNow
    //                },
    //                new ProductCategoryEntity
    //                {
    //                    Name = "Mobilni uređaji (demo)",
    //                    IsEnabled = true,
    //                    CreatedAtUtc = DateTime.UtcNow
    //                }
    //            );

    //            await context.SaveChangesAsync();
    //            Console.WriteLine("✅ Dynamic seed: product categories added.");
    //        }
    //    }

    /// <summary>
    /// Kreira demo korisnike ako ih još nema u bazi.
    /// </summary>
    private static async Task SeedUsersAsync(DatabaseContext context)
    {
        if (await context.UserTable.AnyAsync())
            return;

        var hasher = new PasswordHasher<UsersEntity>();

        var admin = new UsersEntity
        {
            Email = "admin@market.local",
            Password = hasher.HashPassword(null!, "Admin123!"),
        };

        var user = new UsersEntity
        {
            Email = "manager@market.local",
            Password = hasher.HashPassword(null!, "User123!"),
        };

        var dummyForSwagger = new UsersEntity
        {
            Email = "string",
            Password = hasher.HashPassword(null!, "string"),
        };
        var dummyForTests = new UsersEntity
        {
            Email = "test",
            Password = hasher.HashPassword(null!, "test123"),
        };
        context.UserTable.AddRange(admin, user, dummyForSwagger, dummyForTests);
        await context.SaveChangesAsync();

        Console.WriteLine("✅ Dynamic seed: demo users added.");
    }
}