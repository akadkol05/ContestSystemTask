namespace ContestSystem.Api.Models
{
    public class Contest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string AccessLevel { get; set; } = "Normal"; // VIP or Normal
        public string Prize { get; set; } = string.Empty;
        public List<Question> Questions { get; set; } = new();
    }
}