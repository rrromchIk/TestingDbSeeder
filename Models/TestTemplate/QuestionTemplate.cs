﻿using DatabaseSeed.Models.Test;

namespace DatabaseSeed.Models.TestTemplate;

public class QuestionTemplate : BaseEntity
{
    public Guid QuestionsPoolTemplateId { get; set; }
    public QuestionsPoolTemplate QuestionsPoolTemplate { get; set; } = null!;
    public string? DefaultText { get; set; }
    public int? MaxScoreRestriction { get; set; }
    public ICollection<AnswerTemplate> AnswerTemplates { get; set; } = null!;
    public ICollection<Question> QuestionsFromTemplate { get; set; } = null!;
}