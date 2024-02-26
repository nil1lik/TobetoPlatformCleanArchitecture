using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProfileLanguageConfiguration : IEntityTypeConfiguration<ProfileLanguage>
{
    public void Configure(EntityTypeBuilder<ProfileLanguage> builder)
    {
        builder.ToTable("ProfileLanguages").HasKey(pl => pl.Id);

        builder.Property(pl => pl.Id).HasColumnName("Id").IsRequired();
        builder.Property(pl => pl.UserProfileId).HasColumnName("UserProfileId");
        builder.Property(pl => pl.LanguageId).HasColumnName("LanguageId");
        builder.Property(pl => pl.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pl => pl.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pl => pl.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pl => !pl.DeletedDate.HasValue);
    }
}