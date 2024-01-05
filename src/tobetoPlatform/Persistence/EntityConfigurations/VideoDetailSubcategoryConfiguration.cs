using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class VideoDetailSubcategoryConfiguration : IEntityTypeConfiguration<VideoDetailSubcategory>
{
    public void Configure(EntityTypeBuilder<VideoDetailSubcategory> builder)
    {
        builder.ToTable("VideoDetailSubcategories").HasKey(vds => vds.Id);

        builder.Property(vds => vds.Id).HasColumnName("Id").IsRequired();
        builder.Property(vds => vds.VideoDetailCategoryId).HasColumnName("VideoDetailCategoryId");
        builder.Property(vds => vds.Name).HasColumnName("Name");
        builder.Property(vds => vds.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(vds => vds.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(vds => vds.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(vds => !vds.DeletedDate.HasValue);
    }
}