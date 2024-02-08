using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class VideoDetailCategoryConfiguration : IEntityTypeConfiguration<VideoDetailCategory>
{
    public void Configure(EntityTypeBuilder<VideoDetailCategory> builder)
    {
        builder.ToTable("VideoDetailCategories").HasKey(vdc => vdc.Id);

        builder.Property(vdc => vdc.Id).HasColumnName("Id").IsRequired();
        builder.Property(vdc => vdc.Name).HasColumnName("Name");
        builder.Property(vdc => vdc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(vdc => vdc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(vdc => vdc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(vdc => !vdc.DeletedDate.HasValue);
    }
}