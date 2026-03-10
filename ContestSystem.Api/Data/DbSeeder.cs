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
                // 1. Normal Contest (Accessible by Everyone)
                var normalContest = new Contest
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
                    Text = "What is the capital of France?",
                    Points = 10,
                    Type = "Single",
                    Options = new List<Option> {
                        new Option { Text = "Paris", IsCorrect = true },
                        new Option { Text = "London", IsCorrect = false },
                        new Option { Text = "Berlin", IsCorrect = false }
                    }
                }
            }
                };

                // 2. VIP Contest (Accessible by VIP only)
                var vipContest = new Contest
                {
                    Name = "Crypto Masters VIP",
                    Description = "Advanced blockchain quiz.",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(3),
                    AccessLevel = "VIP",
                    Prize = "0.5 ETH",
                    Questions = new List<Question>
            {
                new Question {
                    Text = "Who created Bitcoin?",
                    Points = 50,
                    Type = "Single",
                    Options = new List<Option> {
                        new Option { Text = "Satoshi Nakamoto", IsCorrect = true },
                        new Option { Text = "Elon Musk", IsCorrect = false },
                        new Option { Text = "Vitalik Buterin", IsCorrect = false }
                    }
                }
            }
                };

                context.Contests.AddRange(normalContest, vipContest);
                context.SaveChanges();
            }
        }
    }
}