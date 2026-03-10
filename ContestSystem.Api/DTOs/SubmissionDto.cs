namespace ContestSystem.Api.DTOs
{
    public class SubmissionDto
    {
        public int ContestId { get; set; }
        public List<AnswerDto> Answers { get; set; } = new();
    }

    public class AnswerDto
    {
        public int QuestionId { get; set; }
        public int OptionId { get; set; }
    }
}