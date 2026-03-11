using ContestSystem.Api.Data;
using ContestSystem.Api.DTOs;
using ContestSystem.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.RateLimiting;

[Route("api/[controller]")]
[ApiController]
[EnableRateLimiting("fixed")] // Enforces the rate limit you set in Program.cs
public class ContestController : ControllerBase
{
    private readonly AppDbContext _context;
    public ContestController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetContests()
    {
        try
        {
            var role = User.FindFirstValue(ClaimTypes.Role);

            // Use Include and ThenInclude to pull the seeded Questions and Options
            var query = _context.Contests
                .Include(c => c.Questions)
                    .ThenInclude(q => q.Options)
                .AsQueryable();

            // Access Level Logic
            if (string.IsNullOrEmpty(role) || role == "1")
                query = query.Where(c => c.AccessLevel == "Normal");

            var results = await query.ToListAsync();
            return Ok(results);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error fetching contests", details = ex.Message });
        }
    }

    [HttpGet("leaderboard")]
    public async Task<IActionResult> GetLeaderboard()
    {
        try {
            var data = await _context.Submissions
                .Include(s => s.User)
                .Where(s => s.IsCompleted)
                .GroupBy(s => s.User.Username)
                .Select(g => new { Username = g.Key, TotalScore = g.Sum(x => x.Score) })
                .OrderByDescending(x => x.TotalScore)
                .ToListAsync();
            return Ok(data);
        }
        catch (Exception ex) {
            return StatusCode(500, new { message = "Error loading leaderboard", details = ex.Message });
        }
    }

    [HttpGet("my-history")]
    [Authorize]
    public async Task<IActionResult> GetMyHistory()
    {
        try {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var history = await _context.Submissions
                .Include(s => s.Contest)
                .Where(s => s.UserId == userId)
                .Select(s => new {
                    ContestName = s.Contest.Name,
                    ScoreObtained = s.Score,
                    Date = s.SubmittedAt,
                    Prize = s.Score >= 50 ? s.Contest.Prize : "No Prize"
                })
                .ToListAsync();
            return Ok(history);
        }
        catch (Exception ex) {
            return StatusCode(500, new { message = "Error fetching history", details = ex.Message });
        }
    }

    // --- NEW ADMIN RIGHTS SECTION ---

    // Admin Proof: Get EVERY submission in the system (Normal users get 403 Forbidden)
    [HttpGet("admin/all-submissions")]
    [Authorize(Roles = "3")] 
    public async Task<IActionResult> GetAllSubmissions()
    {
        try {
            var allSubmissions = await _context.Submissions
                .Include(s => s.User)
                .Include(s => s.Contest)
                .Select(s => new { s.User.Username, s.Contest.Name, s.Score, s.SubmittedAt })
                .ToListAsync();
            return Ok(allSubmissions);
        }
        catch (Exception ex) {
            return StatusCode(500, new { message = "Admin access failed", details = ex.Message });
        }
    }

    // Admin Proof: Ability to delete a contest
    [HttpDelete("admin/delete-contest/{id}")]
    [Authorize(Roles = "3")]
    public async Task<IActionResult> DeleteContest(int id)
    {
        try {
            var contest = await _context.Contests.FindAsync(id);
            if (contest == null) return NotFound();
            _context.Contests.Remove(contest);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Contest deleted successfully by Admin." });
        }
        catch (Exception ex) {
            return StatusCode(500, new { message = "Delete failed", details = ex.Message });
        }
    }

    [HttpPost("submit")]
    [Authorize]
    public async Task<IActionResult> Submit([FromBody] SubmissionDto dto)
    {
        try {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            if (await _context.Submissions.AnyAsync(s => s.UserId == userId && s.ContestId == dto.ContestId))
                return BadRequest(new { message = "Already participated in this contest." });

            var contest = await _context.Contests.Include(c => c.Questions).ThenInclude(q => q.Options)
                .FirstOrDefaultAsync(c => c.Id == dto.ContestId);

            if (contest == null) return NotFound("Contest not found.");

            int score = 0;
            foreach (var ans in dto.Answers)
            {
                var q = contest.Questions.FirstOrDefault(x => x.Id == ans.QuestionId);
                if (q == null) continue;

                var correctIds = q.Options.Where(o => o.IsCorrect).Select(o => o.Id).ToList();
                if (correctIds.Count == ans.SelectedOptionIds.Count && !correctIds.Except(ans.SelectedOptionIds).Any())
                    score += q.Points;
            }

            var submission = new Submission {
                UserId = userId, ContestId = dto.ContestId, Score = score,
                IsCompleted = true, SubmittedAt = DateTime.Now
            };

            _context.Submissions.Add(submission);
            await _context.SaveChangesAsync();

            return Ok(new { score, prize = score >= 50 ? contest.Prize : "Participation Certificate" });
        }
        catch (Exception ex) {
            return StatusCode(500, new { message = "Submission failed", details = ex.Message });
        }
    }
    [HttpGet("{id}/questions")]
    [Authorize]
    public async Task<IActionResult> GetQuestions(int id)
    {
        var questions = await _context.Questions
            .Include(q => q.Options)
            .Where(q => q.ContestId == id)
            .Select(q => new {
                q.Id,
                q.Text,
                q.Points,
                q.Type,
                Options = q.Options.Select(o => new { o.Id, o.Text }) // Don't send 'IsCorrect' to frontend!
            })
            .ToListAsync();

        return Ok(questions);
    }
}