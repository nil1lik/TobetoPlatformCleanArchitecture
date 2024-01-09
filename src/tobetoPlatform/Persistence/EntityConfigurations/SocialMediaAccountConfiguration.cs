using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SocialMediaAccountConfiguration : IEntityTypeConfiguration<SocialMediaAccount>
{
    public void Configure(EntityTypeBuilder<SocialMediaAccount> builder)
    {
        builder.ToTable("SocialMediaAccounts").HasKey(sma => sma.Id);

        builder.Property(sma => sma.Id).HasColumnName("Id").IsRequired();
        builder.Property(sma => sma.UserProfileId).HasColumnName("UserProfileId");
        builder.Property(sma => sma.SocialMediaCategoryId).HasColumnName("SocialMediaCategoryId");
        builder.Property(sma => sma.MediaUrl).HasColumnName("MediaUrl").IsRequired();
        builder.Property(sma => sma.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sma => sma.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sma => sma.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(sma => !sma.DeletedDate.HasValue);
    }
}