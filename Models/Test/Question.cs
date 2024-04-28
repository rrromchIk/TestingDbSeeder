﻿using DatabaseSeed.Models.TestTemplate;

namespace DatabaseSeed.Models.Test;

public class Question : BaseEntity
{
    public string Text { get; set; } = null!;
    public int MaxScore { get; set; }
    public Guid? TemplateId { get; set; }
    public QuestionTemplate? QuestionTemplate { get; set; }
    
    public Guid QuestionsPoolId { get; set; }
    public QuestionsPool QuestionsPool { get; set; } = null!;

    public ICollection<UserAnswer> UserAnswers { get; set; } = null!;
    public ICollection<Answer> Answers { get; set; } = null!;

    public ICollection<UserQuestion> UserQuestions { get; set; } = null!;
}