using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EducationPathConfiguration : IEntityTypeConfiguration<EducationPath>
{
    public void Configure(EntityTypeBuilder<EducationPath> builder)
    {
        builder.ToTable("EducationPaths").HasKey(ep => ep.Id);

        builder.Property(ep => ep.Id).HasColumnName("Id").IsRequired();
        builder.Property(ep => ep.EducationAdmirationId).HasColumnName("EducationAdmirationId");
        builder.Property(ep => ep.EducationAboutId).HasColumnName("EducationAboutId");
        builder.Property(ep => ep.Name).HasColumnName("Name");
        builder.Property(ep => ep.ImageUrl).HasColumnName("ImageUrl");
        builder.Property(ep => ep.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ep => ep.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ep => ep.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ep => !ep.DeletedDate.HasValue);
    }
}