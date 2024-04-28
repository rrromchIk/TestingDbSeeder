using DatabaseSeed.Models.Test;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingApi.Data.EntityConfigurations;

namespace DatabaseSeed.Data.EntityConfigurations;

public class QuestionsPoolEntityConfiguration : BaseEntityConfiguration<QuestionsPool>
{
    public override void Configure(EntityTypeBuilder<QuestionsPool> builder)
    {
        base.Configure(builder);

        builder
            .HasMany(qp => qp.Questions)
            .WithOne(q => q.QuestionsPool)
            .HasForeignKey(q => q.QuestionsPoolId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(qp => qp.TemplateId).IsRequired(false);
    }
}