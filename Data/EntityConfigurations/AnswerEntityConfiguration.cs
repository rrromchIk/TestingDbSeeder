using DatabaseSeed.Models.Test;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingApi.Data.EntityConfigurations;

namespace DatabaseSeed.Data.EntityConfigurations;

public class AnswerEntityConfiguration : BaseEntityConfiguration<Answer>
{
    public override void Configure(EntityTypeBuilder<Answer> builder)
    {
        base.Configure(builder);
        
        builder.Property(qt => qt.TemplateId).IsRequired(false);
    }
    
}