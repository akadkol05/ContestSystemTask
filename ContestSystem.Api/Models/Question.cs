namespace ContestSystem.Api.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int Points { get; set; }
        public string Type { get; set; } 
        public int ContestId { get; set; }
        public List<Option> Options { get; set; } = new();
    }
}