using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProfileGraduationConfiguration : IEntityTypeConfiguration<ProfileGraduation>
{
    public void Configure(EntityTypeBuilder<ProfileGraduation> builder)
    {
        builder.ToTable("ProfileGraduations").HasKey(pg => pg.Id);

        builder.Property(pg => pg.Id).HasColumnName("Id").IsRequired();
        builder.Property(pg => pg.GraduationId).HasColumnName("GraduationId");
        builder.Property(pg => pg.UserProfileId).HasColumnName("UserProfileId");
        builder.Property(pg => pg.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pg => pg.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pg => pg.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pg => !pg.DeletedDate.HasValue);
    }
}