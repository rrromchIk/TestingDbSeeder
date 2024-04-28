using DatabaseSeed.Models.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingApi.Data.EntityConfigurations;

namespace DatabaseSeed.Data.EntityConfigurations;

public class UserEntityConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(u => u.ProfilePictureFilePath).IsRequired(false);

        builder
            .HasIndex(u => u.Email)
            .IsUnique();
    }
}