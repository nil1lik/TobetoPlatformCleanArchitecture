using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LessonVideoDetailVideoDetailCategoryConfiguration : IEntityTypeConfiguration<LessonVideoDetailVideoDetailCategory>
{
    public void Configure(EntityTypeBuilder<LessonVideoDetailVideoDetailCategory> builder)
    {
        builder.ToTable("LessonVideoDetailVideoDetailCategories").HasKey(lvdvdc => lvdvdc.Id);

        builder.Property(lvdvdc => lvdvdc.Id).HasColumnName("Id").IsRequired();
        builder.Property(lvdvdc => lvdvdc.LessonVideoDetailId).HasColumnName("LessonVideoDetailId");
        builder.Property(lvdvdc => lvdvdc.VideoDetailCategoryId).HasColumnName("VideoDetailCategoryId");
        builder.Property(lvdvdc => lvdvdc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(lvdvdc => lvdvdc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(lvdvdc => lvdvdc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(lvdvdc => !lvdvdc.DeletedDate.HasValue);
    }
}