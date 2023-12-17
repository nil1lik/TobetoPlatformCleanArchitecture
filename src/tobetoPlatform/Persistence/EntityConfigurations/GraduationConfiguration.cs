using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class GraduationConfiguration : IEntityTypeConfiguration<Graduation>
{
    public void Configure(EntityTypeBuilder<Graduation> builder)
    {
        builder.ToTable("Graduations").HasKey(g => g.Id);

        builder.Property(g => g.Id).HasColumnName("Id").IsRequired();
        builder.Property(g => g.Degree).HasColumnName("Degree");
        builder.Property(g => g.UniversityName).HasColumnName("UniversityName");
        builder.Property(g => g.Department).HasColumnName("Department");
        builder.Property(g => g.StartDate).HasColumnName("StartDate");
        builder.Property(g => g.EndDate).HasColumnName("EndDate");
        builder.Property(g => g.GraduationDate).HasColumnName("GraduationDate");
        builder.Property(g => g.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(g => g.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(g => g.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(g => !g.DeletedDate.HasValue);
    }
}