using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CourseLessonConfiguration : IEntityTypeConfiguration<CourseLesson>
{
    public void Configure(EntityTypeBuilder<CourseLesson> builder)
    {
        builder.ToTable("CourseLessons").HasKey(cl => cl.Id);

        builder.Property(cl => cl.Id).HasColumnName("Id").IsRequired();
        builder.Property(cl => cl.CourseId).HasColumnName("CourseId");
        builder.Property(cl => cl.AsyncLessonId).HasColumnName("AsyncLessonId");
        builder.Property(cl => cl.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cl => cl.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cl => cl.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cl => !cl.DeletedDate.HasValue);
    }
}