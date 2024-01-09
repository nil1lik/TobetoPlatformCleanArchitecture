using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AsyncLessonConfiguration : IEntityTypeConfiguration<AsyncLesson>
{
    public void Configure(EntityTypeBuilder<AsyncLesson> builder)
    {
        builder.ToTable("AsyncLessons").HasKey(al => al.Id);

        builder.Property(al => al.Id).HasColumnName("Id").IsRequired();
        builder.Property(al => al.LessonVideoDetailId).HasColumnName("LessonVideoDetailId");
        builder.Property(al => al.VideoCategoryId).HasColumnName("VideoCategoryId");
        builder.Property(al => al.LessonTypeId).HasColumnName("LessonTypeId");
        builder.Property(al => al.Name).HasColumnName("Name");
        builder.Property(al => al.Time).HasColumnName("Time");
        builder.Property(al => al.VideoUrl).HasColumnName("VideoUrl");
        builder.Property(al => al.IsCompleted).HasColumnName("IsCompleted");
        builder.Property(al => al.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(al => al.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(al => al.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(al => !al.DeletedDate.HasValue);
    }
}