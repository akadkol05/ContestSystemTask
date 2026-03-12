namespace ContestSystem.Api.Models
{
    public class Submission
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int ContestId { get; set; }
        public Contest Contest { get; set; } = null!;
        public int Score { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime SubmittedAt { get; set; }
    }
}