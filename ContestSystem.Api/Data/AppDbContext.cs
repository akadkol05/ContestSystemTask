using Microsoft.EntityFrameworkCore;
using ContestSystem.Api.Models;

namespace ContestSystem.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Contest> Contests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Submission> Submissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Existing Admin Seed
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Username = "SuperAdmin",
                Email = "admin@gmail.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("SecretPassword123!"),
                Role = "3"
            });

            // 2. Your Existing 4 Contests
            modelBuilder.Entity<Contest>().HasData(
                new Contest { Id = 1, Name = "Basic C# Quiz", Description = "General Knowledge", AccessLevel = "Normal", Prize = "Bronze Medal", StartTime = DateTime.Parse("2026-03-11"), EndTime = DateTime.Parse("2026-03-18") },
                new Contest { Id = 2, Name = "SQL Logic", Description = "Database Quiz", AccessLevel = "Normal", Prize = "Silver Medal", StartTime = DateTime.Parse("2026-03-11"), EndTime = DateTime.Parse("2026-03-18") },
                new Contest { Id = 3, Name = "VIP Algorithms", Description = "Pro Level", AccessLevel = "VIP", Prize = "Gold Trophy", StartTime = DateTime.Parse("2026-03-11"), EndTime = DateTime.Parse("2026-03-18") },
                new Contest { Id = 4, Name = "System Design", Description = "Architecture", AccessLevel = "VIP", Prize = "Platinum Trophy", StartTime = DateTime.Parse("2026-03-11"), EndTime = DateTime.Parse("2026-03-18") }
            );

            // 3. Adding Questions to these Contests
            modelBuilder.Entity<Question>().HasData(
                new Question { Id = 1, ContestId = 1, Text = "What is the base class for all types in .NET?", Type = "Single", Points = 10 },
                new Question { Id = 2, ContestId = 2, Text = "Which SQL clause is used to filter groups?", Type = "Single", Points = 20 },
                new Question { Id = 3, ContestId = 3, Text = "Which algorithms are O(n log n)?", Type = "Multi", Points = 50 },
                new Question { Id = 4, ContestId = 4, Text = "What is the primary benefit of microservices?", Type = "Single", Points = 100 }
            );

            // 4. Adding Options for the Questions
            modelBuilder.Entity<Option>().HasData(
                // Q1 Options (Contest 1)
                new Option { Id = 1, QuestionId = 1, Text = "System.Object", IsCorrect = true },
                new Option { Id = 2, QuestionId = 1, Text = "System.Base", IsCorrect = false },

                // Q2 Options (Contest 2)
                new Option { Id = 3, QuestionId = 2, Text = "HAVING", IsCorrect = true },
                new Option { Id = 4, QuestionId = 2, Text = "WHERE", IsCorrect = false },

                // Q3 Options (Contest 3 - Multi)
                new Option { Id = 5, QuestionId = 3, Text = "Merge Sort", IsCorrect = true },
                new Option { Id = 6, QuestionId = 3, Text = "Quick Sort", IsCorrect = true },
                new Option { Id = 7, QuestionId = 3, Text = "Bubble Sort", IsCorrect = false },

                // Q4 Options (Contest 4)
                new Option { Id = 8, QuestionId = 4, Text = "Scalability", IsCorrect = true },
                new Option { Id = 9, QuestionId = 4, Text = "Monolithic simplicity", IsCorrect = false }
            );
        }
    }
}