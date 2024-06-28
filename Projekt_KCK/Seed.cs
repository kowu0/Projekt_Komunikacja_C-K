using Projekt_KCK.Entities;

namespace Projekt_KCK
{
    public static class Seed
    {
        public static void SeedAdminUser(AppDbContext context)
        {
            if (!context.User.Any(u => u.Username == "admin"))
            {
                var adminUser = new RegisteredUser
                {
                   // Email = "admin@admin.com",
                    Username = "admin",
                    Password = BCrypt.Net.BCrypt.HashPassword("admin"),
                    Role = "admin"
                };

                context.User.Add(adminUser);
                context.SaveChanges();
            }
        }
    }
}
