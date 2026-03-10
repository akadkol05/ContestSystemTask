using Microsoft.EntityFrameworkCore;
using ContestSystem.Api.Models; // <--- THIS MUST BE HERE
using System;

namespace ContestSystem.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Contest> Contests { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Option> Options { get; set; } = null!;
        public DbSet<Submission> Submissions { get; set; } = null!;
    }
}