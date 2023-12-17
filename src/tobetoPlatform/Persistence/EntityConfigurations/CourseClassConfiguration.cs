using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CourseClassConfiguration : IEntityTypeConfiguration<CourseClass>
{
    public void Configure(EntityTypeBuilder<CourseClass> builder)
    {
        builder.ToTable("CourseClasses").HasKey(cc => cc.Id);

        builder.Property(cc => cc.Id).HasColumnName("Id").IsRequired();
        builder.Property(cc => cc.ProfileAnnouncementId).HasColumnName("ProfileAnnouncementId");
        builder.Property(cc => cc.Name).HasColumnName("Name");
        builder.Property(cc => cc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cc => cc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cc => cc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cc => !cc.DeletedDate.HasValue);
    }
}