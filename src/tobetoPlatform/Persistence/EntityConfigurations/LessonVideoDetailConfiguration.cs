using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LessonVideoDetailConfiguration : IEntityTypeConfiguration<LessonVideoDetail>
{
    public void Configure(EntityTypeBuilder<LessonVideoDetail> builder)
    {
        builder.ToTable("LessonVideoDetails").HasKey(lvd => lvd.Id);

        builder.Property(lvd => lvd.Id).HasColumnName("Id").IsRequired();
        builder.Property(lvd => lvd.VideoLanguageId).HasColumnName("VideoLanguageId");
        builder.Property(lvd => lvd.CompanyId).HasColumnName("CompanyId");
        builder.Property(lvd => lvd.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(lvd => lvd.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(lvd => lvd.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(lvd => !lvd.DeletedDate.HasValue);
    }
}