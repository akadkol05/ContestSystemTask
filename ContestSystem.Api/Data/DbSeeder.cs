using ContestSystem.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ContestSystem.Api.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Contests.Any())
            {
                var contest = new Contest
                {
                    Name = "General Knowledge Quiz",
                    Description = "Basic quiz for everyone.",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(7),
                    AccessLevel = "Normal",
                    Prize = "Certificate",
                    Questions = new List<Question>
                    {
                        new Question {
                            Text = "What is 2+2?",
                            Points = 10,
                            Type = "Single",
                            Options = new List<Option> {
                                new Option { Text = "4", IsCorrect = true },
                                new Option { Text = "5", IsCorrect = false }
                            }
                        }
                    }
                };
                context.Contests.Add(contest);
                context.SaveChanges();
            }
        }
    }
}