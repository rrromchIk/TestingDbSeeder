﻿using DatabaseSeed.Data.EntityConfigurations;
using DatabaseSeed.Models.Test;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestingApi.Data.EntityConfigurations;

public class QuestionEntityConfiguration : BaseEntityConfiguration<Question>
{
    public override void Configure(EntityTypeBuilder<Question> builder)
    {
        base.Configure(builder);

        builder
            .HasMany(q => q.Answers)
            .WithOne(a => a.Question)
            .HasForeignKey(a => a.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(q => q.UserAnswers)
            .WithOne(ua => ua.Question)
            .HasForeignKey(ua => ua.QuestionId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Property(q => q.TemplateId).IsRequired(false);
    }
}