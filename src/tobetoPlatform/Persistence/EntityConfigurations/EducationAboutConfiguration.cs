using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EducationAboutConfiguration : IEntityTypeConfiguration<EducationAbout>
{
    public void Configure(EntityTypeBuilder<EducationAbout> builder)
    {
        builder.ToTable("EducationAbouts").HasKey(ea => ea.Id);

        builder.Property(ea => ea.Id).HasColumnName("Id").IsRequired();
        builder.Property(ea => ea.CompanyId).HasColumnName("CompanyId");
        builder.Property(ea => ea.EducationAboutCategoryId).HasColumnName("EducationAboutCategoryId");
        builder.Property(ea => ea.StartDate).HasColumnName("StartDate");
        builder.Property(ea => ea.EndDate).HasColumnName("EndDate");
        builder.Property(ea => ea.EstimatedDuration).HasColumnName("EstimatedDuration");
        builder.Property(ea => ea.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ea => ea.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ea => ea.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ea => !ea.DeletedDate.HasValue);
    }
}