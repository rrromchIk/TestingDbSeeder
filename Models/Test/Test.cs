namespace DatabaseSeed.Models.Test;

public class Test : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Subject { get; set; } = null!;
    public int Duration { get; set; }
    public bool IsPublished { get; set; }
    public TestDifficulty Difficulty { get; set; }
    public Guid? TemplateId { get; set; }
    //public int? NumOfQuestions { get; set; }
    
    public TestTemplate.TestTemplate? TestTemplate { get; set; }

    public ICollection<QuestionsPool> QuestionsPools { get; set; } = null!;
    public ICollection<UserTest> UserTests { get; set; } = null!;
}