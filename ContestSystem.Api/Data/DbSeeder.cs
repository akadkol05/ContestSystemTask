using ContestSystem.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ContestSystem.Api.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context, IConfiguration configuration)
        {
            try
            {
                context.Database.EnsureCreated();

                // Fix: Use "3" instead of UserRole.Admin
                if (!context.Users.Any(u => u.Role == "3"))
                {
                    var adminSettings = configuration.GetSection("AdminUser");
                    var admin = new User
                    {
                        Username = adminSettings["Username"] ?? "SuperAdmin",
                        Email = adminSettings["Email"] ?? "admin@system.com",
                        Role = "3",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword(adminSettings["Password"] ?? "SecretPassword123!")
                    };
                    context.Users.Add(admin);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Seeding failed: {ex.Message}");
            }
        }
    }
}