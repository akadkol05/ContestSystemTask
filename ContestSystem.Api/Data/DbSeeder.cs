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
                    Name = "Mixed Quiz Challenge",
                    Description = "Test your knowledge with different question types.",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(10),
                    AccessLevel = "Normal",
                    Prize = "Tech Badge",
                    Questions = new List<Question>
            {
                // 1. True/False Type
                new Question {
                    Text = "The Earth is flat.", Points = 5, Type = "TrueFalse",
                    Options = new List<Option> {
                        new Option { Text = "True", IsCorrect = false },
                        new Option { Text = "False", IsCorrect = true }
                    }
                },
                // 2. Multi-Select Type
                new Question {
                    Text = "Which of these are programming languages?", Points = 20, Type = "Multi",
                    Options = new List<Option> {
                        new Option { Text = "C#", IsCorrect = true },
                        new Option { Text = "Python", IsCorrect = true },
                        new Option { Text = "HTML", IsCorrect = false } // HTML is markup
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