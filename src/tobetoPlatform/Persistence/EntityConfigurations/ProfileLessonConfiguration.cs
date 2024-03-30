using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProfileLessonConfiguration : IEntityTypeConfiguration<ProfileLesson>
{
    public void Configure(EntityTypeBuilder<ProfileLesson> builder)
    {
        builder.ToTable("ProfileLessons").HasKey(pl => pl.Id);

        builder.Property(pl => pl.Id).HasColumnName("Id").IsRequired();
        builder.Property(pl => pl.UserProfileId).HasColumnName("UserProfileId");
        builder.Property(pl => pl.AsyncLessonId).HasColumnName("AsyncLessonId");
        builder.Property(pl => pl.IsWatched).HasColumnName("IsWatched");
        builder.Property(pl => pl.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pl => pl.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pl => pl.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pl => !pl.DeletedDate.HasValue);
    }
}