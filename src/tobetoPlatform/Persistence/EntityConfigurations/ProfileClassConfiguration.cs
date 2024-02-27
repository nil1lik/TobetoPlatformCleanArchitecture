using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProfileClassConfiguration : IEntityTypeConfiguration<ProfileClass>
{
    public void Configure(EntityTypeBuilder<ProfileClass> builder)
    {
        builder.ToTable("ProfileClasses").HasKey(pc => pc.Id);

        builder.Property(pc => pc.Id).HasColumnName("Id").IsRequired();
        builder.Property(pc => pc.UserProfileId).HasColumnName("UserProfileId");
        builder.Property(pc => pc.CourseClassId).HasColumnName("CourseClassId");
        builder.Property(pc => pc.EducationPathId).HasColumnName("EducationPathId");
        builder.Property(pc => pc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pc => pc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pc => pc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pc => !pc.DeletedDate.HasValue);
    }
}