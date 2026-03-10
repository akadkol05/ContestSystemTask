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

            return Ok(await _context.Contests
                .Include(c => c.Questions)
                    .ThenInclude(q => q.Options)
                .Where(c => userRole == "Admin" || userRole == "VIP" || c.AccessLevel == "Normal")
                .ToListAsync());
        }

        [Authorize]
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitContest(SubmissionDto submission)
        {
            // FIX: Get the ID from the token correctly
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim)) return Unauthorized("Session expired. Please login again.");

            int userId = int.Parse(userIdClaim);
            int totalScore = 0;

            foreach (var answer in submission.Answers)
            {
                // Check if this specific option is marked as 'IsCorrect' in the DB
                var option = await _context.Options
                    .FirstOrDefaultAsync(o => o.Id == answer.OptionId && o.QuestionId == answer.QuestionId);

                if (option != null && option.IsCorrect)
                {
                    var question = await _context.Questions.FindAsync(answer.QuestionId);
                    totalScore += question?.Points ?? 0;
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

            return Ok(new { score = totalScore, message = "Successfully submitted!" });
        }
        // 1. Get User History
        [HttpGet("history")]
        public async Task<IActionResult> GetMyHistory()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return Unauthorized();

            var userId = int.Parse(userIdClaim);

            var history = await _context.Submissions
                .Where(s => s.UserId == userId)
                .Include(s => s.Contest)
                .OrderByDescending(s => s.SubmittedAt)
                .Select(s => new {
                    ContestName = s.Contest.Name,
                    Score = s.Score,
                    Date = s.SubmittedAt,
                   
                    PrizeWon = s.Score > 0 ? s.Contest.Prize : "No Prize"
                })
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
