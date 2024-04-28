﻿using DatabaseSeed.Data.EntityConfigurations;
using DatabaseSeed.Models;
using DatabaseSeed.Models.Test;
using DatabaseSeed.Models.TestTemplate;
using DatabaseSeed.Models.User;
using Microsoft.EntityFrameworkCore;
using TestingApi.Data.EntityConfigurations;

namespace DatabaseSeed.Data;

public class DataContext : DbContext
{
    public DbSet<Test> Tests { get; set; } = null!;
    public DbSet<QuestionsPool> QuestionsPools { get; set; } = null!;
    public DbSet<Question> Questions { get; set; } = null!;
    public DbSet<Answer> Answers { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserTest> UserTests { get; set; } = null!;
    public DbSet<UserAnswer> UserAnswers { get; set; } = null!;
    public DbSet<UserQuestion> UserQuestions { get; set; } = null!;
    public DbSet<TestTemplate> TestTemplates { get; set; } = null!;
    public DbSet<QuestionsPoolTemplate> QuestionsPoolTemplates { get; set; } = null!;
    public DbSet<QuestionTemplate> QuestionTemplates { get; set; } = null!;
    public DbSet<AnswerTemplate> AnswerTemplates { get; set; } = null!;

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TestEntityConfiguration());
        modelBuilder.ApplyConfiguration(new QuestionEntityConfiguration());
        modelBuilder.ApplyConfiguration(new QuestionsPoolEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserTestEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserAnswerEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserQuestionEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TestTemplateEntityConfiguration());
        modelBuilder.ApplyConfiguration(new QuestionPoolTemplateEntityConfiguration());
        modelBuilder.ApplyConfiguration(new QuestionTemplateEntityConfiguration());
        modelBuilder.ApplyConfiguration(new AnswerTemplateEntityConfiguration());
        modelBuilder.ApplyConfiguration(new AnswerEntityConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}