using DatabaseSeed.Models.TestTemplate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseSeed.Data.EntityConfigurations;

public class AnswerTemplateEntityConfiguration : BaseEntityConfiguration<AnswerTemplate>
{
    public override void Configure(EntityTypeBuilder<AnswerTemplate> builder)
    {
        base.Configure(builder);
        
        builder
            .HasMany(a => a.AnswersFromTemplate)
            .WithOne(a => a.AnswerTemplate)
            .HasForeignKey(a => a.TemplateId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.Property(qt => qt.DefaultText).IsRequired(false);
    }
}