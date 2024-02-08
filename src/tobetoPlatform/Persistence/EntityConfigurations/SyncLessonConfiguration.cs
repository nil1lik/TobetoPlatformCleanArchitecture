using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SyncLessonConfiguration : IEntityTypeConfiguration<SyncLesson>
{
    public void Configure(EntityTypeBuilder<SyncLesson> builder)
    {
        builder.ToTable("SyncLessons").HasKey(sl => sl.Id);

        builder.Property(sl => sl.Id).HasColumnName("Id").IsRequired();
        builder.Property(sl => sl.LessonVideoDetailId).HasColumnName("LessonVideoDetailId");
        builder.Property(sl => sl.CourseId).HasColumnName("CourseId");
        builder.Property(sl => sl.SyncVideoUrl).HasColumnName("SyncVideoUrl");
        builder.Property(sl => sl.SessionName).HasColumnName("SessionName");
        builder.Property(sl => sl.StartDate).HasColumnName("StartDate");
        builder.Property(sl => sl.EndDate).HasColumnName("EndDate");
        builder.Property(sl => sl.IsJoin).HasColumnName("IsJoin");
        builder.Property(sl => sl.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sl => sl.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sl => sl.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(sl => !sl.DeletedDate.HasValue);
    }
}