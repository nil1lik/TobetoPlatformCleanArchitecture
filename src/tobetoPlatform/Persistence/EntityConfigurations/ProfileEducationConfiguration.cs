using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProfileEducationConfiguration : IEntityTypeConfiguration<ProfileEducation>
{
    public void Configure(EntityTypeBuilder<ProfileEducation> builder)
    {
        builder.ToTable("ProfileEducations").HasKey(pe => pe.Id);

        builder.Property(pe => pe.Id).HasColumnName("Id").IsRequired();
        builder.Property(pe => pe.UserProfileId).HasColumnName("UserProfileId");
        builder.Property(pe => pe.EducationPathId).HasColumnName("EducationPathId");
        builder.Property(pe => pe.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pe => pe.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pe => pe.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pe => !pe.DeletedDate.HasValue);
    }
}