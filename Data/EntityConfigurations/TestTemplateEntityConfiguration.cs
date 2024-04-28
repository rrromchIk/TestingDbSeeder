using DatabaseSeed.Models.TestTemplate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingApi.Data.EntityConfigurations;

namespace DatabaseSeed.Data.EntityConfigurations;

public class TestTemplateEntityConfiguration : BaseEntityConfiguration<TestTemplate>
{
    public override void Configure(EntityTypeBuilder<TestTemplate> builder)
    {
        base.Configure(builder);

        builder
            .HasMany(t => t.QuestionsPoolTemplates)
            .WithOne(qp => qp.TestTemplate)
            .HasForeignKey(qp => qp.TestTemplateId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(t => t.TestsFromTemplate)
            .WithOne(t => t.TestTemplate)
            .HasForeignKey(t => t.TemplateId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(tp => tp.TemplateName).IsUnique();
        builder.Property(tp => tp.DefaultTestDifficulty).IsRequired(false);
        builder.Property(tp => tp.DefaultSubject).IsRequired(false);
        builder.Property(tp => tp.DefaultDuration).IsRequired(false);
    }
}