using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EducationAboutCategoryConfiguration : IEntityTypeConfiguration<EducationAboutCategory>
{
    public void Configure(EntityTypeBuilder<EducationAboutCategory> builder)
    {
        builder.ToTable("EducationAboutCategories").HasKey(eac => eac.Id);

        builder.Property(eac => eac.Id).HasColumnName("Id").IsRequired();
        builder.Property(eac => eac.Name).HasColumnName("Name");
        builder.Property(eac => eac.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(eac => eac.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(eac => eac.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(eac => !eac.DeletedDate.HasValue);
    }
}