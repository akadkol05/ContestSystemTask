namespace ContestSystem.Api.DTOs
{
    public class SubmissionDto
    {
        public int ContestId { get; set; }
        public List<AnswerDto> Answers { get; set; } = new List<AnswerDto>();
    }

    public class AnswerDto
    {
        public int QuestionId { get; set; }
        public List<int> SelectedOptionIds { get; set; } = new List<int>();
    }
}