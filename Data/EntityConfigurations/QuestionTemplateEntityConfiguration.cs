using DatabaseSeed.Models.TestTemplate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingApi.Data.EntityConfigurations;

namespace DatabaseSeed.Data.EntityConfigurations;

public class QuestionTemplateEntityConfiguration : BaseEntityConfiguration<QuestionTemplate>
{
    public override void Configure(EntityTypeBuilder<QuestionTemplate> builder)
    {
        base.Configure(builder);

        builder
            .HasMany(q => q.AnswerTemplates)
            .WithOne(a => a.QuestionTemplate)
            .HasForeignKey(a => a.QuestionTemplateId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasMany(q => q.QuestionsFromTemplate)
            .WithOne(q => q.QuestionTemplate)
            .HasForeignKey(q => q.TemplateId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Property(qt => qt.DefaultText).IsRequired(false);
        builder.Property(qt => qt.MaxScoreRestriction).IsRequired(false);
    }
}