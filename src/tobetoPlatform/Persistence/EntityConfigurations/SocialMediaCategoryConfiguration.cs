using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SocialMediaCategoryConfiguration : IEntityTypeConfiguration<SocialMediaCategory>
{
    public void Configure(EntityTypeBuilder<SocialMediaCategory> builder)
    {
        builder.ToTable("SocialMediaCategories").HasKey(smc => smc.Id);

        builder.Property(smc => smc.Id).HasColumnName("Id").IsRequired();
        builder.Property(smc => smc.Name).HasColumnName("Name");
        builder.Property(smc => smc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(smc => smc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(smc => smc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(smc => !smc.DeletedDate.HasValue);
    }
}