using DatabaseSeed.Models.Test;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingApi.Data.EntityConfigurations;

namespace DatabaseSeed.Data.EntityConfigurations;

public class TestEntityConfiguration : BaseEntityConfiguration<Test>
{
    public override void Configure(EntityTypeBuilder<Test> builder)
    {
        base.Configure(builder);

        builder
            .HasMany(t => t.QuestionsPools)
            .WithOne(qp => qp.Test)
            .OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(qp => qp.TestId);

        builder
            .HasIndex(t => t.Name)
            .IsUnique();
        
        builder.Property(t => t.TemplateId).IsRequired(false);
        //builder.Property(t => t.NumOfQuestions).IsRequired(false);
    }
}