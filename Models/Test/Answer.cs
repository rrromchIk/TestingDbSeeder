using DatabaseSeed.Models.TestTemplate;

namespace DatabaseSeed.Models.Test;

public class Answer : BaseEntity
{
    public Guid QuestionId { get; set; }
    public Question Question { get; set; } = null!;

    public string Text { get; set; } = null!;
    public bool IsCorrect { get; set; }
    public Guid? TemplateId { get; set; }
    public AnswerTemplate? AnswerTemplate { get; set; }
}