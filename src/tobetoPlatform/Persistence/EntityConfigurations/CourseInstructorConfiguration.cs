using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CourseInstructorConfiguration : IEntityTypeConfiguration<CourseInstructor>
{
    public void Configure(EntityTypeBuilder<CourseInstructor> builder)
    {
        builder.ToTable("CourseInstructors").HasKey(ci => ci.Id);

        builder.Property(ci => ci.Id).HasColumnName("Id").IsRequired();
        builder.Property(ci => ci.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ci => ci.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ci => ci.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ci => !ci.DeletedDate.HasValue);
    }
}