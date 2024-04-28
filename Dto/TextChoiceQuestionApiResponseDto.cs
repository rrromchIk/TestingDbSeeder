namespace DatabaseSeed.Dto;

public class TextChoiceQuestionApiResponseDto
{
    public string Difficulty { get; set; } = null!;
    public QuestionApiResponseDto Question { get; set; } = null!;
    public string CorrectAnswer { get; set; } = null!;
    public List<string> IncorrectAnswers { get; set; } = null!;
}