using ContestSystem.Api.Data;
using ContestSystem.Api.DTOs;
using ContestSystem.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ContestSystem.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContestController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContestController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<IActionResult> GetContests()
        {
            var userRole = User.FindFirstValue(ClaimTypes.Role);

            // Logic: If Normal, hide VIP. If VIP/Admin, show all.
            var contests = await _context.Contests
                .Where(c => userRole == "VIP" || userRole == "Admin" || c.AccessLevel == "Normal")
                .ToListAsync();

            return Ok(contests);
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitContest(SubmissionDto submission)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            int totalScore = 0;

            foreach (var answer in submission.Answers)
            {
                var isCorrect = await _context.Options
                    .AnyAsync(o => o.Id == answer.OptionId && o.IsCorrect && o.QuestionId == answer.QuestionId);

                if (isCorrect)
                {
                    var points = await _context.Questions
                        .Where(q => q.Id == answer.QuestionId)
                        .Select(q => q.Points)
                        .FirstOrDefaultAsync();
                    totalScore += points;
                }
            }

            var newSubmission = new Submission
            {
                UserId = userId,
                ContestId = submission.ContestId,
                Score = totalScore,
                SubmittedAt = DateTime.UtcNow
            };

            _context.Submissions.Add(newSubmission);
            await _context.SaveChangesAsync();

            return Ok(new { Score = totalScore, Message = "Contest Submitted!" });
        }
        // 1. Get User History
        [HttpGet("history")]
        public async Task<IActionResult> GetMyHistory()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var history = await _context.Submissions
                .Where(s => s.UserId == userId)
                .Include(s => s.Contest) // Shows the name of the contest
                .OrderByDescending(s => s.SubmittedAt)
                .ToListAsync();

            return Ok(history);
        }

        // 2. Get Global Leaderboard
        [HttpGet("leaderboard")]
        public async Task<IActionResult> GetLeaderboard()
        {
            var leaderboard = await _context.Submissions
                .GroupBy(s => s.UserId)
                .Select(g => new {
                    UserId = g.Key,
                    TotalScore = g.Sum(s => s.Score),
                    ContestsPlayed = g.Count()
                })
                .OrderByDescending(x => x.TotalScore)
                .Take(10) // Top 10 users
                .ToListAsync();

            return Ok(leaderboard);
        }
    }
}
