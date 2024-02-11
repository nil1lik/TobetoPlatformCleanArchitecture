using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProfileSkillConfiguration : IEntityTypeConfiguration<ProfileSkill>
{
    public void Configure(EntityTypeBuilder<ProfileSkill> builder)
    {
        builder.ToTable("ProfileSkills").HasKey(ps => ps.Id);

        builder.Property(ps => ps.Id).HasColumnName("Id").IsRequired();
        builder.Property(ps => ps.UserProfileId).HasColumnName("UserProfileId");
        builder.Property(ps => ps.SkillId).HasColumnName("SkillId");
        builder.Property(ps => ps.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ps => ps.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ps => ps.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ps => !ps.DeletedDate.HasValue);
    }
}